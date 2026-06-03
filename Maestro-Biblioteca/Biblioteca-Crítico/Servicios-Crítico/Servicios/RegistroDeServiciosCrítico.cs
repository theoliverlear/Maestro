using Microsoft.Extensions.DependencyInjection;

namespace Maestro.Biblioteca.Crítico.Servicios;

public static class RegistroDeServiciosCrítico
{
    public static IServiceCollection RegistrarServiciosCrítico(this IServiceCollection servicios)
    {
        servicios.AddScoped<IServicioCrítico, ServicioCrítico>();
        return servicios;
    }
}
