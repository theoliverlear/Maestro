using Maestro.Datos;
using Maestro.Repositorio;
using Maestro.Repositorio.Usuarios;
using Maestro.Servicio;
using Maestro.Servicio.Autorización.ServicioDeAutorización;
using Maestro.Servicio.Conjugación.ServicioDeConjugación;
using Maestro.Servicio.Palabra.PalabraReal;
using Maestro.Servicio.Sesión.ServicioDeSesión;
using Maestro.Servicio.Usuarios.ServicioDeUsuario;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Settings.Configuration;
using Serilog.Sinks.SystemConsole.Themes;


WebApplicationBuilder constructora = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console(
        outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {RequestPath} {Message:lj}{NewLine}{Exception}",
        applyThemeToRedirectedOutput: true,
        theme: AnsiConsoleTheme.Literate)
    .WriteTo.Debug()
    .CreateLogger();

constructora.Host.UseSerilog();

constructora.Services.AddDistributedMemoryCache();

constructora.Services.AddSession(opciones =>
{
    opciones.Cookie.Name = ".Maestro.Sesión";
    opciones.IdleTimeout = TimeSpan.FromMinutes(30);
    // opciones.Cookie.HttpOnly = true;
});

constructora.Services.AddHttpContextAccessor();

string? cadenaDeConexión = constructora.Configuration.GetConnectionString("MaestroBd");

constructora.Services.AddDbContext<ContextoDeBdMaestro>(opciones =>
{
    opciones.UseNpgsql(cadenaDeConexión, opcionesDeSql =>
    {
        opcionesDeSql.SetPostgresVersion(new Version(17, 0));
    });
});

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

constructora.Services.AddEndpointsApiExplorer();
constructora.Services.AddSwaggerGen();

constructora.Services.AddScoped<IServicioDeAutorización, ServicioDeAutorización>();
constructora.Services.AddScoped<IServicioDeConjugación, ServicioDeConjugación>();
constructora.Services.AddScoped<IServicioPalabraReal, ServicioPalabraReal>();
constructora.Services.AddScoped<IServicioDeSesión, ServicioDeSesión>();
constructora.Services.AddScoped<IServicioDeUsuario, ServicioDeUsuario>();

constructora.Services.AddScoped<IRepositorio, Repositorio>();
constructora.Services.AddScoped<IUsuariosDeRepositorio, UsuariosDeRepositorio>();

WebApplication app = constructora.Build();
app.UseSerilogRequestLogging();
app.UseCors(react);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSession();
app.MapControllers();
app.Run();