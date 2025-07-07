using Maestro.Entidad.Usuario;
using Maestro.Repositorio.Usuario;

namespace Maestro.Servicio.ServicioUsuario;

public class ServicioUsuario : IServicioUsuario
{
    private IUsuariosDeRepositorio _repositorioUsuarios;

    public ServicioUsuario(IUsuariosDeRepositorio repositorioUsuarios)
    {
        this._repositorioUsuarios = repositorioUsuarios;
    }

    public async Task Eliminar(Usuario usuario)
    {
        await this._repositorioUsuarios.EliminarAsíncrono(usuario);
    }

    public async Task Eliminar(int id)
    {
        await this._repositorioUsuarios.EliminarAsíncrono<Usuario>(id);
    }

    public async Task Actualizar(Usuario usuario)
    {
        await this._repositorioUsuarios.ActualizarAsíncrono(usuario);
    }

    public async ValueTask<Usuario> Agregar(Usuario usuario)
    {
        var nuevoUsuario = await this._repositorioUsuarios.AgregarAsíncrono(usuario);
        return nuevoUsuario;
    }
}