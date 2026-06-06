using Maestro.Biblioteca.Api.Comunicación.Solicitud.Autorización;
using Maestro.Biblioteca.Api.Entidad.Usuario;
using Maestro.Biblioteca.Universal.Repositorio;
using Maestro.Biblioteca.Api.Repositorio.Usuarios;
using Maestro.Biblioteca.Api.Servicio.BaseDatos.ServicioDeBaseDatos;

namespace Maestro.Biblioteca.Api.Servicio.Usuarios.ServicioDeUsuario;

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
