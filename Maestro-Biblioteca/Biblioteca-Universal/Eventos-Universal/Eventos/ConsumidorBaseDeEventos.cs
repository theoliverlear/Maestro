using Microsoft.Extensions.Logging;

namespace Maestro.Biblioteca.Universal.Eventos;

public abstract class ConsumidorBaseDeEventos<TSolicitud, TRespuesta>
{
    private readonly IPublicadorDeEventos _publicadorDeEventos;
    private readonly string _enlaceDeSalida;
    private readonly ILogger _log;

    protected ConsumidorBaseDeEventos(IPublicadorDeEventos publicadorDeEventos,
                                      string enlaceDeSalida,
                                      ILogger log)
    {
        this._publicadorDeEventos = publicadorDeEventos;
        this._enlaceDeSalida = enlaceDeSalida;
        this._log = log;
    }

    public async Task ConsumirAsync(TSolicitud solicitud,
                                    IReadOnlyDictionary<string, string> encabezados,
                                    CancellationToken ct = default)
    {
        encabezados.TryGetValue("correlationId", out string? idDeCorrelacion);
        encabezados.TryGetValue("Authorization", out string? autorizacion);
        this._log.LogDebug("Procesando solicitud con correlationId={IdDeCorrelacion}.", idDeCorrelacion);

        TRespuesta respuesta;
        try
        {
            respuesta = await this.ProcesarAsync(solicitud, autorizacion, ct);
        }
        catch (Exception excepcion)
        {
            this._log.LogError(excepcion, "Error procesando solicitud correlationId={IdDeCorrelacion}.", idDeCorrelacion);
            respuesta = this.ManejarError(excepcion);
        }

        Dictionary<string, string> encabezadosDeRespuesta = new();
        if (!string.IsNullOrWhiteSpace(idDeCorrelacion))
        {
            encabezadosDeRespuesta["correlationId"] = idDeCorrelacion;
        }

        if (!string.IsNullOrWhiteSpace(autorizacion))
        {
            encabezadosDeRespuesta["Authorization"] = autorizacion;
        }

        await this._publicadorDeEventos.PublicarAsync(this._enlaceDeSalida, respuesta, encabezadosDeRespuesta, ct);
    }

    protected abstract Task<TRespuesta> ProcesarAsync(TSolicitud solicitud,
                                                      string? encabezadoDeAutorizacion,
                                                      CancellationToken ct);

    protected abstract TRespuesta ManejarError(Exception excepcion);
}
