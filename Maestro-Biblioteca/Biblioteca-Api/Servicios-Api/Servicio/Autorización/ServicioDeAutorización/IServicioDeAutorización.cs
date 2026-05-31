using Maestro.Comunicación.Respuesta.Autorización;
using Maestro.Comunicación.Solicitud.Autorización;

namespace Maestro.Servicio.Autorización.ServicioDeAutorización;

public interface IServicioDeAutorización
{
    RespuestaDeEstadoDeAutorización Acceso(SolicitudInicioDeSesión solicitud);
    Task<RespuestaDeEstadoDeAutorización> Registro(SolicitudDeRegistro solicitud);
    RespuestaDeEstadoDeAutorización Conectado();
}