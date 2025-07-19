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

    public Usuario? ObtenerPorNombreDeUsuario(string nombreDeUsuario)
    {
        if (string.IsNullOrWhiteSpace(nombreDeUsuario))
        {
            return null;
        }

        return this._repositorioUsuarios.ObtenerPorNombreDeUsuario(nombreDeUsuario);
    }

    public Usuario ObtenerEntidadDeSolicitud(SolicitudInicioDeSesión solicitud)
    {
        return Usuario.Constructor()
                      .ConNombreDeUsuario(solicitud.NombreDeUsuario)
                      .ConContraseñaSegura(solicitud.Contraseña)
                      .Construir();
    }
}