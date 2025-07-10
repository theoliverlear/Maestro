using Maestro.Comunicación.Solicitud.Autorización;
using Maestro.Entidad.Usuario;
using Maestro.Repositorio.Usuario;

namespace Maestro.Servicio.Usuarios.ServicioDeUsuario;

public class ServicioDeDeUsuario : IServicioDeUsuario
{
    private IUsuariosDeRepositorio _repositorioUsuarios;

    public ServicioDeDeUsuario(IUsuariosDeRepositorio repositorioUsuarios)
    {
        this._repositorioUsuarios = repositorioUsuarios;
    }

    public Usuario ObtenerEntidadDeSolicitud(SolicitudInicioDeSesión solicitud)
    {
        throw new NotImplementedException();
    }

    public async Task EliminarAsíncrono(Usuario usuario)
    {
        await this._repositorioUsuarios.EliminarAsíncrono(usuario);
    }

    public async Task EliminarAsíncrono(int id)
    {
        await this._repositorioUsuarios.EliminarAsíncrono<Usuario>(id);
    }

    public async Task ActualizarAsíncrono(Usuario usuario)
    {
        await this._repositorioUsuarios.ActualizarAsíncrono(usuario);
    }

    public async ValueTask<Usuario> AgregarAsíncrono(Usuario usuario)
    {
        var nuevoUsuario = await this._repositorioUsuarios.AgregarAsíncrono(usuario);
        return nuevoUsuario;
    }
}