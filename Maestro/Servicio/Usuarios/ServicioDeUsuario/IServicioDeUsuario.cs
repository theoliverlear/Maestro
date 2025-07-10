using Maestro.Comunicación.Solicitud.Autorización;
using Maestro.Entidad.Usuario;

namespace Maestro.Servicio.Usuarios.ServicioDeUsuario;

public interface IServicioDeUsuario : IServicioDeBaseDatos<Usuario>
{
    Usuario ObtenerEntidadDeSolicitud(SolicitudInicioDeSesión solicitud);
}