using Maestro.Repositorio;

namespace Maestro.Servicio.BaseDatos.ServicioDeBaseDatos;

public class ServicioDeBaseDatos<TEntidad> : IServicioDeBaseDatos<TEntidad> where TEntidad : class
{
    private IRepositorio _repositorio;

    public ServicioDeBaseDatos(IRepositorio repositorio)
    {
        this._repositorio = repositorio;
    }

    public async Task EliminarAsíncrono(TEntidad entidad)
    {
        await this._repositorio.EliminarAsíncrono(entidad);
    }

    public async Task EliminarAsíncrono(int id)
    {
        await this._repositorio.EliminarAsíncrono<TEntidad>(id);
    }

    public async Task ActualizarAsíncrono(TEntidad entidad)
    {
        await this._repositorio.ActualizarAsíncrono(entidad);
    }

    public async ValueTask<TEntidad> AgregarAsíncrono(TEntidad entidad)
    {
        return await this._repositorio.AgregarAsíncrono(entidad);
    }
}