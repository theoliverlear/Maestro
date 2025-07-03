using Maestro.Servicio;
using Maestro.Servicio.Conjugación;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

WebApplicationBuilder constructora = WebApplication.CreateBuilder(args);

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

constructora.Services.AddScoped<IServicioDeConjugación, ServicioDeConjugación>();

WebApplication app = constructora.Build();

app.UseCors(react);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();