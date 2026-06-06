using Maestro.Biblioteca.Universal.Eventos.Configuración;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Maestro.Biblioteca.Universal.Configuración;

public static class RegistroUniversal
{
    public static IServiceCollection RegistrarBibliotecaUniversal(this IServiceCollection servicios,
                                                                  IConfiguration configuracion)
    {
        servicios.RegistrarClientesHttpUniversales();
        servicios.RegistrarEventosKafkaUniversales(configuracion);
        return servicios;
    }
}
