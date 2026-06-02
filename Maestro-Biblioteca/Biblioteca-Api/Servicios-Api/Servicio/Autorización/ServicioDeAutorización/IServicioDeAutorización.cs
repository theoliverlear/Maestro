using Maestro.Comunicación.Respuesta.Autorización;
using Maestro.Comunicación.Solicitud.Autorización;

namespace Maestro.Servicio.Autorización.ServicioDeAutorización;

public interface IServicioDeAutorización
{
    Task<RespuestaDeEstadoDeAutorización> Acceso(SolicitudInicioDeSesión solicitud);
    Task<RespuestaDeEstadoDeAutorización> Registro(SolicitudDeRegistro solicitud);
    RespuestaDeEstadoDeAutorización Conectado();
    Task<RespuestaDeEstadoDeAutorización> Actualizar(string idDeToken);
    Task<RespuestaDeEstadoDeAutorización> Salir(string idDeToken);
}
