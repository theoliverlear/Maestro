namespace Maestro.Servicio.BaseDatos.ServicioDeBaseDatos;

public interface IServicioDeBaseDatos<TEntidad>
{
    Task EliminarAsíncrono(TEntidad entidad);
    Task EliminarAsíncrono(int id);
    Task ActualizarAsíncrono(TEntidad entidad);
    ValueTask<TEntidad> AgregarAsíncrono(TEntidad entidad);
}