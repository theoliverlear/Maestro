using Maestro.Comunicación.Respuesta.Autorización;
using Maestro.Comunicación.Solicitud.Autorización;

namespace Maestro.Servicio.Autorización.ServicioDeAutorización;

public interface IServicioDeAutorización
{
    RespuestaDeEstadoDeAutorización Acceso(SolicitudInicioDeSesión solicitud);
    RespuestaDeEstadoDeAutorización Registro(SolicitudDeRegistro solicitud);
}