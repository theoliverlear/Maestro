using Maestro.Biblioteca.Crítico.Eventos;
using Maestro.Biblioteca.Crítico.Servicios;
using Maestro.Biblioteca.Universal.Configuración;
using Microsoft.Extensions.Hosting;

HostApplicationBuilderSettings configuración = new()
{
    Args = args,
    ContentRootPath = AppContext.BaseDirectory
};
HostApplicationBuilder constructor = Host.CreateApplicationBuilder(configuración);
await constructor.Configuration.CargarSecretosAws(constructor.Environment);

constructor.Services.RegistrarBibliotecaUniversal(constructor.Configuration);
constructor.Services.RegistrarServiciosCrítico();
constructor.Services.RegistrarConsumidorDeSolicitudesCrítico();

IHost app = constructor.Build();
await app.RunAsync();
