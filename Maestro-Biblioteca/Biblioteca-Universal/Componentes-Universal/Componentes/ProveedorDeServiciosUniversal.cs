using Microsoft.Extensions.DependencyInjection;

namespace Maestro.Biblioteca.Universal.Componentes;

public static class ProveedorDeServiciosUniversal
{
    private static IServiceProvider? proveedor;

    public static void EstablecerProveedor(IServiceProvider proveedorDeServicios)
    {
        proveedor = proveedorDeServicios;
    }

    public static TServicio ObtenerServicioRequerido<TServicio>() where TServicio : notnull
    {
        if (proveedor == null)
        {
            throw new InvalidOperationException("El proveedor de servicios universal no ha sido establecido.");
        }

        return proveedor.GetRequiredService<TServicio>();
    }
}
