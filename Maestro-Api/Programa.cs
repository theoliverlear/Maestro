using Maestro.Biblioteca.Universal.Componentes.Datos;
using Maestro.Biblioteca.Crítico.Eventos;
using Maestro.Biblioteca.Universal.Configuración;
using Maestro.Biblioteca.Api.Infraestructura;
using Maestro.Biblioteca.Api.Modelos.Autorización.Dpop;
using Maestro.Biblioteca.Universal.Repositorio;
using Maestro.Biblioteca.Api.Servicio.Autorización.ServicioDpop;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Settings.Configuration;
using Serilog.Sinks.SystemConsole.Themes;


WebApplicationBuilder constructora = WebApplication.CreateBuilder(args);
await constructora.Configuration.CargarSecretosAws(constructora.Environment);
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", Serilog.Events.LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console(
        outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}",
        applyThemeToRedirectedOutput: true,
        theme: AnsiConsoleTheme.Literate)
    .WriteTo.Debug()
    .CreateLogger();

constructora.Host.UseSerilog();

constructora.Services.AddDistributedMemoryCache();
constructora.Services.AddMemoryCache();

constructora.Services.AddSession(opciones =>
{
    opciones.Cookie.Name = ".Maestro.Sesion";
    opciones.IdleTimeout = TimeSpan.FromMinutes(30);
    // opciones.Cookie.HttpOnly = true;
});

constructora.Services.AddHttpContextAccessor();

string? cadenaDeConexión = constructora.Configuration.GetConnectionString("MaestroBd");
string claveJwt = constructora.Configuration.ObtenerClaveJwt(constructora.Environment);
string emisorJwt = constructora.Configuration["Jwt:Emisor"] ?? "Maestro";
string audienciaJwt = constructora.Configuration["Jwt:Audiencia"] ?? "Maestro-Sitio-Web";

constructora.Services.AddDbContext<ContextoDeBdMaestro>(opciones =>
{
    opciones.UseNpgsql(cadenaDeConexión, opcionesDeSql =>
    {
        opcionesDeSql.SetPostgresVersion(new Version(17, 0));
        opcionesDeSql.MigrationsAssembly("Maestro.Api");
    });
});
constructora.Services.AddScoped<IRepositorio, Repositorio<ContextoDeBdMaestro>>();

const string react = "React";

constructora.Services.AddCors(opciones =>
{
    opciones.AddPolicy(react, póliza => póliza
        .WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
    );
});

constructora.Services.AddControllers();
constructora.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opciones =>
    {
        opciones.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = emisorJwt,
            ValidateAudience = true,
            ValidAudience = audienciaJwt,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(claveJwt)),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30)
        };
        opciones.Events = new JwtBearerEvents
        {
            OnMessageReceived = contexto =>
            {
                string? autorización = contexto.Request.Headers.Authorization.FirstOrDefault();
                if (autorización?.StartsWith("DPoP ", StringComparison.OrdinalIgnoreCase) == true)
                {
                    contexto.Token = autorización["DPoP ".Length..].Trim();
                }
                return Task.CompletedTask;
            },
            OnTokenValidated = contexto =>
            {
                string? confirmación = contexto.Principal?.FindFirst("cnf")?.Value;
                if (string.IsNullOrWhiteSpace(confirmación))
                {
                    return Task.CompletedTask;
                }

                string? huellaDelToken = JsonDocument.Parse(confirmación)
                    .RootElement
                    .GetProperty("jkt")
                    .GetString();
                string? huellaDePrueba = contexto.HttpContext.Items["dpop.prueba"] is ContextoDePruebaDpop prueba
                    ? prueba.HuellaDeClave
                    : null;
                if (string.IsNullOrWhiteSpace(huellaDePrueba) ||
                    huellaDePrueba != huellaDelToken)
                {
                    contexto.Fail("La prueba DPoP no coincide con el token.");
                }
                return Task.CompletedTask;
            }
        };
    });
constructora.Services.AddAuthorization();
constructora.Services.RegistrarBibliotecaUniversal(constructora.Configuration);
constructora.Services.RegistrarComunicadorCrítico();
constructora.Services.RegistrarConsumidorDeRespuestasCrítico();
constructora.Services.AddScoped<IAlmacénDeReproducciónDpop, AlmacénDeReproducciónDpop>();

constructora.Services.AddEndpointsApiExplorer();
constructora.Services.AddSwaggerGen();

constructora.Services.Scan(escáner => escáner
    .FromApplicationDependencies()
    .AddClasses(clase => clase.Where(tipo => tipo.Name.StartsWith("Servicio")))
    .AsImplementedInterfaces()
    .WithScopedLifetime()
    .AddClasses(clase => clase.Where(tipo => tipo.Name.EndsWith("Repositorio")))
    .AsImplementedInterfaces()
    .WithScopedLifetime()
);

WebApplication app = constructora.Build();
app.UseSerilogRequestLogging(opciones =>
{
    opciones.MessageTemplate =
        "HTTP {RequestMethod} {RutaDecodificada} responded {StatusCode} in {Elapsed:0.00} ms";

    opciones.EnrichDiagnosticContext = (contextoDiagnostico, contextoHttp) =>
    {
        contextoDiagnostico.Set(
            "RutaDecodificada",
            contextoHttp.Request.Path.Value ?? string.Empty);
    };
});
app.UseCors(react);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSession();
app.UseMiddleware<MiddlewareDpop>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
