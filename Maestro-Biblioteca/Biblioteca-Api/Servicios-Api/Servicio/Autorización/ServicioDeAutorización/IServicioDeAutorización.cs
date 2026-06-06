using Maestro.Biblioteca.Api.Comunicación.Respuesta.Autorización;
using Maestro.Biblioteca.Api.Comunicación.Solicitud.Autorización;

namespace Maestro.Biblioteca.Api.Servicio.Autorización.ServicioDeAutorización;

public interface IServicioDeAutorización
{
    Task<RespuestaDeEstadoDeAutorización> Acceso(SolicitudInicioDeSesión solicitud);
    Task<RespuestaDeEstadoDeAutorización> Registro(SolicitudDeRegistro solicitud);
    RespuestaDeEstadoDeAutorización Conectado();
    Task<RespuestaDeEstadoDeAutorización> Actualizar(string idDeToken);
    Task<RespuestaDeEstadoDeAutorización> Salir(string idDeToken);
}
