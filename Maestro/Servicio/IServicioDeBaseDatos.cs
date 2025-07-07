namespace Maestro.Servicio;

public interface IServicioDeBaseDatos<TEntidad>
{
    Task Eliminar(TEntidad entidad);
    Task Eliminar(int id);
    Task Actualizar(TEntidad entidad);
    ValueTask<TEntidad> Agregar(TEntidad entidad);
}