using Microsoft.Extensions.DependencyInjection;

namespace Maestro.Biblioteca.Crítico.Eventos;

public static class RegistroDeEventosCrítico
{
    public static IServiceCollection RegistrarComunicadorCrítico(this IServiceCollection servicios)
    {
        servicios.AddSingleton<ComunicadorCrítico>();
        return servicios;
    }

    public static IServiceCollection RegistrarConsumidorDeRespuestasCrítico(this IServiceCollection servicios)
    {
        servicios.AddHostedService<ConsumidorDeRespuestasCrítico>();
        return servicios;
    }

    public static IServiceCollection RegistrarConsumidorDeSolicitudesCrítico(this IServiceCollection servicios)
    {
        servicios.AddHostedService<ConsumidorDeSolicitudesCrítico>();
        return servicios;
    }
}
