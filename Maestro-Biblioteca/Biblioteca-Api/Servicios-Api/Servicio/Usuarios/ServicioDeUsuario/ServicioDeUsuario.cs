using Maestro.Comunicación.Solicitud.Autorización;
using Maestro.Entidad.Usuario;
using Maestro.Repositorio;
using Maestro.Repositorio.Usuarios;
using Maestro.Servicio.BaseDatos.ServicioDeBaseDatos;

namespace Maestro.Servicio.Usuarios.ServicioDeUsuario;

public class ServicioDeUsuario : ServicioDeBaseDatos<Usuario>, IServicioDeUsuario
{
    private IUsuariosDeRepositorio _repositorioUsuarios;

    public ServicioDeUsuario(IUsuariosDeRepositorio repositorioUsuarios,
                             IRepositorio repositorio) : base(repositorio)
    {
        this._repositorioUsuarios = repositorioUsuarios;
    }

    public Usuario? ObtenerPorId(int id)
    {
        if (id <= 0)
        {
            return null;
        }

        return this._repositorioUsuarios.ObtenerPorId(id);
    }

    public Usuario? ObtenerPorNombreDeUsuario(string nombreDeUsuario)
    {
        if (string.IsNullOrWhiteSpace(nombreDeUsuario))
        {
            return null;
        }

        return this._repositorioUsuarios.ObtenerPorNombreDeUsuario(nombreDeUsuario);
    }

    public Usuario? ObtenerPorCorreoElectrónico(string correoElectrónico)
    {
        if (string.IsNullOrWhiteSpace(correoElectrónico))
        {
            return null;
        }

        return this._repositorioUsuarios.ObtenerPorCorreoElectrónico(correoElectrónico);
    }

    public Usuario ObtenerEntidadDeSolicitud(SolicitudInicioDeSesión solicitud)
    {
        return Usuario.Constructor()
                      .ConCorreoElectrónico(solicitud.CorreoElectrónico)
                      .ConContraseñaSegura(solicitud.Contraseña)
                      .Construir();
    }
}
