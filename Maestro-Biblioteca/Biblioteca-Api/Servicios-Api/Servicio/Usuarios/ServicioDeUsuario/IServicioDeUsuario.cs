using Maestro.Biblioteca.Api.Comunicación.Solicitud.Autorización;
using Maestro.Biblioteca.Api.Entidad.Usuario;
using Maestro.Biblioteca.Api.Servicio.BaseDatos.ServicioDeBaseDatos;

namespace Maestro.Biblioteca.Api.Servicio.Usuarios.ServicioDeUsuario;

public interface IServicioDeUsuario : IServicioDeBaseDatos<Usuario>
{
    Usuario ObtenerEntidadDeSolicitud(SolicitudInicioDeSesión solicitud);
    Usuario? ObtenerPorId(int id);
    Usuario? ObtenerPorNombreDeUsuario(string nombreDeUsuario);
    Usuario? ObtenerPorCorreoElectrónico(string correoElectrónico);
}
