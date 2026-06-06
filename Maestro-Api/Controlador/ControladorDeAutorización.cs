using System.Net;
using Maestro.Biblioteca.Api.Comunicación.Respuesta.Autorización;
using Maestro.Biblioteca.Api.Comunicación.Solicitud.Autorización;
using Maestro.Biblioteca.Api.Servicio.Autorización.ServicioDeAutorización;
using Microsoft.AspNetCore.Mvc;

namespace Maestro.Api.Controlador;

[ApiController, Route("api/autorización")]
public class ControladorDeAutorización : ControllerBase
{
    private const string NombreCookieTokenDeActualización = "maestro_rt";
    private readonly IServicioDeAutorización _servicioDeAutorización;
    public ControladorDeAutorización(IServicioDeAutorización servicioDeAutorización)
    {
        this._servicioDeAutorización = servicioDeAutorización;
    }

    [HttpPost("acceso")]
    public async Task<ActionResult<RespuestaDeEstadoDeAutorización>> Acceso(SolicitudInicioDeSesión solicitud)
    {
        RespuestaDeEstadoDeAutorización estadoDeAutorización =
            await this._servicioDeAutorización.Acceso(solicitud);
        this.EscribirCookieDeActualización(estadoDeAutorización);
        HttpStatusCode códigoDeEstado = estadoDeAutorización.EsAutorizado ? HttpStatusCode.OK : HttpStatusCode.Unauthorized;
        return StatusCode((int) códigoDeEstado, estadoDeAutorización);
    }

    [HttpPost("registro")]
    public async Task<ActionResult<RespuestaDeEstadoDeAutorización>> Registro(SolicitudDeRegistro solicitud)
    {
        RespuestaDeEstadoDeAutorización estadoDeAutorización =
            await this._servicioDeAutorización.Registro(solicitud);
        this.EscribirCookieDeActualización(estadoDeAutorización);
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

    [HttpPost("actualizar")]
    public async Task<ActionResult<RespuestaDeEstadoDeAutorización>> Actualizar()
    {
        string? idDeToken = Request.Cookies[NombreCookieTokenDeActualización];
        if (string.IsNullOrWhiteSpace(idDeToken))
        {
            return Unauthorized(new RespuestaDeEstadoDeAutorización(false));
        }

        RespuestaDeEstadoDeAutorización estadoDeAutorización =
            await this._servicioDeAutorización.Actualizar(idDeToken);
        this.EscribirCookieDeActualización(estadoDeAutorización);
        HttpStatusCode códigoDeEstado = estadoDeAutorización.EsAutorizado ? HttpStatusCode.OK : HttpStatusCode.Unauthorized;
        return StatusCode((int)códigoDeEstado, estadoDeAutorización);
    }

    [HttpPost("salir")]
    public async Task<ActionResult<RespuestaDeEstadoDeAutorización>> Salir()
    {
        string? idDeToken = Request.Cookies[NombreCookieTokenDeActualización];
        if (!string.IsNullOrWhiteSpace(idDeToken))
        {
            await this._servicioDeAutorización.Salir(idDeToken);
        }

        Response.Cookies.Delete(NombreCookieTokenDeActualización, this.OpcionesDeCookie());
        return Ok(new RespuestaDeEstadoDeAutorización(false));
    }

    private void EscribirCookieDeActualización(RespuestaDeEstadoDeAutorización respuesta)
    {
        if (!respuesta.EsAutorizado ||
            string.IsNullOrWhiteSpace(respuesta.IdDeTokenDeActualización) ||
            respuesta.ExpiraTokenDeActualizaciónEn == null)
        {
            return;
        }

        CookieOptions opciones = this.OpcionesDeCookie();
        opciones.Expires = respuesta.ExpiraTokenDeActualizaciónEn;
        Response.Cookies.Append(NombreCookieTokenDeActualización,
            respuesta.IdDeTokenDeActualización,
            opciones);
    }

    private CookieOptions OpcionesDeCookie()
    {
        return new CookieOptions
        {
            HttpOnly = true,
            Secure = false,
            SameSite = SameSiteMode.Strict,
            Path = "/api/autorización"
        };
    }
}
