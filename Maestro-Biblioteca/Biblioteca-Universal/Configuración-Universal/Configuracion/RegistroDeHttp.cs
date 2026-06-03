using Microsoft.Extensions.DependencyInjection;

namespace Maestro.Biblioteca.Universal.Configuracion;

public static class RegistroDeHttp
{
    public static IServiceCollection RegistrarClientesHttpUniversales(this IServiceCollection servicios)
    {
        servicios.AddHttpClient();
        return servicios;
    }
}
