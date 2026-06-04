using Maestro.Biblioteca.Universal.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Maestro.Biblioteca.Universal.Servicios.EntityFramework;

public static class RegistroDeServiciosEntityFramework
{
    public static IServiceCollection RegistrarServicioEntityFrameworkDeEntidad<TContexto, TEntidad, TId>(
        this IServiceCollection servicios)
        where TContexto : DbContext
        where TEntidad : class, IIdentificable<TId>
        where TId : notnull
    {
        servicios.AddScoped<IGestorDeEntidad<TEntidad, TId>,
            ServicioEntityFrameworkDeEntidad<TEntidad, TId, TContexto>>();
        servicios.AddScoped<IConsultaDeEntidad<TEntidad, TId>>(proveedor =>
            proveedor.GetRequiredService<IGestorDeEntidad<TEntidad, TId>>());
        servicios.AddScoped<IPersistenciaDeEntidad<TEntidad, TId>>(proveedor =>
            proveedor.GetRequiredService<IGestorDeEntidad<TEntidad, TId>>());
        return servicios;
    }
}
