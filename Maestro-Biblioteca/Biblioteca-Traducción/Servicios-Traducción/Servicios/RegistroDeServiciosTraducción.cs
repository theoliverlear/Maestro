using Microsoft.Extensions.DependencyInjection;

namespace Maestro.Biblioteca.Traducción.Servicios;

public static class RegistroDeServiciosTraducción
{
    public static IServiceCollection RegistrarServiciosTraducción(this IServiceCollection servicios)
    {
        servicios.AddSingleton<IServicioTraducción, ServicioTraducción>();
        return servicios;
    }
}
