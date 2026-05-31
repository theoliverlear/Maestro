using System.Net;
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
        HttpStatusCode códigoDeEstado = estadoDeAutorización.EsAutorizado ? HttpStatusCode.OK : HttpStatusCode.Unauthorized;
        return StatusCode((int) códigoDeEstado, estadoDeAutorización);
    }

    [HttpPost("registro")]
    public async Task<ActionResult<RespuestaDeEstadoDeAutorización>> Registro(SolicitudDeRegistro solicitud)
    {
        RespuestaDeEstadoDeAutorización estadoDeAutorización =
            await this._servicioDeAutorización.Registro(solicitud);
        HttpStatusCode códigoDeEstado = estadoDeAutorización.EsAutorizado ? HttpStatusCode.OK : HttpStatusCode.Unauthorized;
        return StatusCode((int) códigoDeEstado, estadoDeAutorización);
    }

    [HttpGet("conectado")]
    public ActionResult<RespuestaDeEstadoDeAutorización> Conectado()
    {
        RespuestaDeEstadoDeAutorización estadoDeAutorización =
            this._servicioDeAutorización.Conectado();
        HttpStatusCode códigoDeEstado = estadoDeAutorización.EsAutorizado ? HttpStatusCode.OK : HttpStatusCode.Unauthorized;
        return StatusCode((int) códigoDeEstado, estadoDeAutorización);
    }
}