using Maestro.Biblioteca.Traducción.Comunicación.Respuesta;
using Maestro.Biblioteca.Traducción.Comunicación.Solicitud;
using Maestro.Biblioteca.Traducción.Eventos;
using Microsoft.AspNetCore.Mvc;

namespace Maestro.Api.Controlador;

[ApiController]
[Route("api/traducción")]
public class ControladorDeTraducción : ControllerBase
{
    private readonly ComunicadorTraducción _comunicador;
    private readonly ILogger<ControladorDeTraducción> _log;

    public ControladorDeTraducción(ComunicadorTraducción comunicador,
                                   ILogger<ControladorDeTraducción> log)
    {
        this._comunicador = comunicador;
        this._log = log;
    }

    [HttpPost("traducir")]
    public async Task<ActionResult<RespuestaTraducción>> TraducirAsync(
        [FromBody] SolicitudTraducción solicitud,
        CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(solicitud.Texto))
        {
            return this.BadRequest("El texto para traducir es obligatorio.");
        }

        string? autorización = this.Request.Headers.Authorization.FirstOrDefault();
        this._log.LogInformation(
            "Enviando solicitud de Traducción desde {LenguajeDeOrigen}.",
            solicitud.LenguajeDeOrigen);
        try
        {
            RespuestaTraducción respuesta = await this._comunicador.EjecutarAsync(
                EnlacesTraducción.Solicitudes,
                solicitud,
                TimeSpan.FromSeconds(15),
                autorización,
                ct);
            return this.Ok(respuesta);
        }
        catch (Exception excepción)
        {
            this._log.LogError(excepción, "Error enviando solicitud de Traducción.");
            return this.BadRequest(excepción.Message);
        }
    }
}
