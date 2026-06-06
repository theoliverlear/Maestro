using Maestro.Biblioteca.Traducción.Eventos;
using Maestro.Biblioteca.Traducción.Servicios;
using Maestro.Biblioteca.Universal.Configuración;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

HostApplicationBuilderSettings configuración = new()
{
    Args = args,
    ContentRootPath = AppContext.BaseDirectory
};
HostApplicationBuilder constructor = Host.CreateApplicationBuilder(configuración);
await constructor.Configuration.CargarSecretosAws(constructor.Environment);
constructor.Logging.ClearProviders();
constructor.Logging.AddConsole();

constructor.Services.RegistrarBibliotecaUniversal(constructor.Configuration);
constructor.Services.RegistrarServiciosTraducción();
constructor.Services.RegistrarConsumidorDeSolicitudesTraducción();

IHost app = constructor.Build();
await app.RunAsync();
