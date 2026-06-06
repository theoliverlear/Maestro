using Microsoft.Extensions.DependencyInjection;

namespace Maestro.Biblioteca.Traducción.Eventos;

public static class RegistroDeEventosTraducción
{
    public static IServiceCollection RegistrarComunicadorTraducción(this IServiceCollection servicios)
    {
        servicios.AddSingleton<ComunicadorTraducción>();
        return servicios;
    }

    public static IServiceCollection RegistrarConsumidorDeRespuestasTraducción(this IServiceCollection servicios)
    {
        servicios.AddHostedService<ConsumidorDeRespuestasTraducción>();
        return servicios;
    }

    public static IServiceCollection RegistrarConsumidorDeSolicitudesTraducción(this IServiceCollection servicios)
    {
        servicios.AddHostedService<ConsumidorDeSolicitudesTraducción>();
        return servicios;
    }
}
