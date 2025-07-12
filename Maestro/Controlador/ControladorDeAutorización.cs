using Maestro.Comunicación.Respuesta.Autorización;
using Maestro.Comunicación.Solicitud.Autorización;
using Maestro.Modelos.Autorización;
using Maestro.Servicio.Autorización.ServicioDeAutorización;
using Microsoft.AspNetCore.Mvc;

namespace Maestro.Controlador;

[ApiController, Route("api/autorización")]
public class ControladorDeAutorización : ControllerBase
{
    private readonly IServicioDeAutorización _servicioDeAutorización;
    public ControladorDeAutorización(IServicioDeAutorización servicioDeAutorización)
    {
        this._servicioDeAutorización = servicioDeAutorización;
    }

    [HttpPost("acceso")]
    public ActionResult<RespuestaDeEstadoDeAutorización> Acceso(SolicitudInicioDeSesión solicitud)
    {
        RespuestaDeEstadoDeAutorización estadoDeAutorización =
            this._servicioDeAutorización.Acceso(solicitud);
        int códigoDeEstado = estadoDeAutorización.EsAutorizado ? 200 : 401;
        return StatusCode(códigoDeEstado, estadoDeAutorización);
    }

    [HttpPost("registro")]
    public ActionResult<RespuestaDeEstadoDeAutorización> Registro(SolicitudDeRegistro solicitud)
    {
        RespuestaDeEstadoDeAutorización estadoDeAutorización =
            this._servicioDeAutorización.Registro(solicitud);
        int códigoDeEstado = estadoDeAutorización.EsAutorizado ? 200 : 400;
        return StatusCode(códigoDeEstado, estadoDeAutorización);
    }
}