using Maestro.Comunicación.Solicitud.Autorización;
using Maestro.Entidad.Usuario;
using Maestro.Servicio.BaseDatos.ServicioDeBaseDatos;

namespace Maestro.Servicio.Usuarios.ServicioDeUsuario;

public interface IServicioDeUsuario : IServicioDeBaseDatos<Usuario>
{
    Usuario ObtenerEntidadDeSolicitud(SolicitudInicioDeSesión solicitud);
    Usuario? ObtenerPorNombreDeUsuario(string nombreDeUsuario);
}