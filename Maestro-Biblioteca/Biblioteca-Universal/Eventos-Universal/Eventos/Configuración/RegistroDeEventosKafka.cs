using Maestro.Biblioteca.Universal.Eventos.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Maestro.Biblioteca.Universal.Eventos.Configuración;

public static class RegistroDeEventosKafka
{
    public static IServiceCollection RegistrarEventosKafkaUniversales(this IServiceCollection servicios,
                                                                      IConfiguration configuracion)
    {
        servicios.Configure<OpcionesDeKafka>(configuracion.GetSection(OpcionesDeKafka.Seccion));
        servicios.AddSingleton<ProveedorDeTemasKafka>();
        servicios.AddSingleton<IPublicadorDeEventos, PublicadorKafkaDeEventos>();
        return servicios;
    }
}
