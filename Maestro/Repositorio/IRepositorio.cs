namespace Maestro.Repositorio;

public interface IRepositorio
{
    Task GuardarCambiosAsíncronos();
    ValueTask<TEntidad?> ObtenerPorIdAsíncrono<TEntidad>(int id) where TEntidad : class;
    ValueTask<TEntidad> AgregarAsíncrono<TEntidad>(TEntidad entidad) where TEntidad : class;
    Task ActualizarAsíncrono<TEntidad>(TEntidad entidad) where TEntidad : class;
    Task EliminarAsíncrono<TEntidad>(int id) where TEntidad : class;
    Task EliminarAsíncrono<TEntidad>(TEntidad entidad) where TEntidad : class;
}