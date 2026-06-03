using Maestro.Biblioteca.Universal.Componentes;
using Maestro.Biblioteca.Universal.Eventos.Configuracion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Maestro.Biblioteca.Universal.Configuracion;

public static class RegistroUniversal
{
    public static IServiceCollection RegistrarBibliotecaUniversal(this IServiceCollection servicios,
                                                                  IConfiguration configuracion)
    {
        servicios.Configure<OpcionesDeCaracteristicasUniversales>(
            configuracion.GetSection(OpcionesDeCaracteristicasUniversales.Seccion));
        servicios.AddSingleton<InterruptoresDeSistema>();
        servicios.RegistrarClientesHttpUniversales();
        servicios.RegistrarEventosKafkaUniversales(configuracion);
        return servicios;
    }
}
