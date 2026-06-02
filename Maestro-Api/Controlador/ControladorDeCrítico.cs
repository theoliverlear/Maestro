using Maestro.Biblioteca.Crítico.Comunicacion.Respuesta;
using Maestro.Biblioteca.Crítico.Comunicacion.Solicitud;
using Maestro.Biblioteca.Crítico.Eventos;
using Microsoft.AspNetCore.Mvc;

namespace Maestro.Controlador;

[ApiController]
[Route("api/crítico")]
public class ControladorDeCrítico : ControllerBase
{
    private readonly ComunicadorCrítico _comunicador;
    private readonly ILogger<ControladorDeCrítico> _log;

    public ControladorDeCrítico(ComunicadorCrítico comunicador,
                                ILogger<ControladorDeCrítico> log)
    {
        this._comunicador = comunicador;
        this._log = log;
    }

    [HttpPost("solicitudes")]
    public async Task<ActionResult<RespuestaCrítico>> EnviarSolicitudAsync(
        [FromBody] SolicitudCrítico solicitud,
        CancellationToken ct)
    {
        string? autorización = this.Request.Headers.Authorization.FirstOrDefault();
        this._log.LogInformation("Enviando solicitud genérica de Crítico tipo {Tipo}.", solicitud.Tipo);
        try
        {
            RespuestaCrítico respuesta = await this._comunicador.EjecutarAsync(
                EnlacesCrítico.Solicitudes,
                solicitud,
                TimeSpan.FromSeconds(15),
                autorización,
                ct);
            return this.Ok(respuesta);
        }
        catch (Exception excepción)
        {
            this._log.LogError(excepción, "Error enviando solicitud genérica de Crítico.");
            return this.BadRequest(RespuestaCrítico.Error(excepción.Message));
        }
    }
}
