using Maestro.Comunicación.Solicitud.Autorización;
using Maestro.Entidad.Usuario;
using Maestro.Repositorio.Usuarios;

namespace Maestro.Servicio.Usuarios.ServicioDeUsuario;

public class ServicioDeUsuario : IServicioDeUsuario
{
    private IUsuariosDeRepositorio _repositorioUsuarios;

    public ServicioDeUsuario(IUsuariosDeRepositorio repositorioUsuarios)
    {
        this._repositorioUsuarios = repositorioUsuarios;
    }

    public Usuario? ObtenerPorNombreDeUsuario(string nombreDeUsuario)
    {
        if (string.IsNullOrWhiteSpace(nombreDeUsuario))
        {
            return null;
        }

        var usuario = this._repositorioUsuarios.ObtenerPorNombreDeUsuario(nombreDeUsuario);
        return usuario;
    }

    public Usuario ObtenerEntidadDeSolicitud(SolicitudInicioDeSesión solicitud)
    {
        return Usuario.Constructor()
                      .ConNombreDeUsuario(solicitud.NombreDeUsuario)
                      .ConContraseñaSegura(solicitud.Contraseña)
                      .Construir();
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