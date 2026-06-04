using System.Collections.Concurrent;

namespace Maestro.Biblioteca.Universal.Eventos;

public abstract class ControladorDeComunicadorDeSolicitud<TSolicitud, TRespuesta> :
    IComunicadorDeSolicitud<TSolicitud, TRespuesta>
{
    private readonly ConcurrentDictionary<string, TaskCompletionSource<TRespuesta>> _respuestasPendientes = new();

    protected virtual TimeSpan EsperaMaximaPredeterminada
    {
        get { return TimeSpan.FromSeconds(15); }
    }

    protected abstract IPublicadorDeEventos PublicadorDeEventos { get; }

    public Task<TRespuesta> EjecutarAsync(IEnlaceDeEvento enlace,
                                          TSolicitud solicitud,
                                          CancellationToken ct = default)
    {
        return this.EjecutarAsync(enlace, solicitud, this.EsperaMaximaPredeterminada, null, ct);
    }

    public Task<TRespuesta> EjecutarAsync(IEnlaceDeEvento enlace,
                                          TSolicitud solicitud,
                                          TimeSpan esperaMaxima,
                                          CancellationToken ct = default)
    {
        return this.EjecutarAsync(enlace, solicitud, esperaMaxima, null, ct);
    }

    public async Task<TRespuesta> EjecutarAsync(IEnlaceDeEvento enlace,
                                                TSolicitud solicitud,
                                                TimeSpan esperaMaxima,
                                                string? encabezadoDeAutorizacion,
                                                CancellationToken ct = default)
    {
        string idDeCorrelacion = this.ObtenerIdDeCorrelacion();
        TaskCompletionSource<TRespuesta> respuesta = new(TaskCreationOptions.RunContinuationsAsynchronously);
        this._respuestasPendientes[idDeCorrelacion] = respuesta;

        Dictionary<string, string> encabezados = this.ObtenerEncabezadosIniciales(idDeCorrelacion, encabezadoDeAutorizacion);
        await this.PublicadorDeEventos.PublicarAsync(enlace.NombreDeEnlace, solicitud, encabezados, ct);

        try
        {
            Task tareaDeEspera = Task.Delay(esperaMaxima, ct);
            Task completada = await Task.WhenAny(respuesta.Task, tareaDeEspera);
            if (completada == respuesta.Task)
            {
                return await respuesta.Task;
            }

            throw new TimeoutException($"No se recibio respuesta para la correlacion {idDeCorrelacion}.");
        }
        finally
        {
            this._respuestasPendientes.TryRemove(idDeCorrelacion, out _);
        }
    }

    public void ManejarRespuesta(string? idDeCorrelacion, TRespuesta respuesta)
    {
        if (string.IsNullOrWhiteSpace(idDeCorrelacion))
        {
            return;
        }

        if (this._respuestasPendientes.TryRemove(idDeCorrelacion, out TaskCompletionSource<TRespuesta>? respuestaPendiente))
        {
            respuestaPendiente.TrySetResult(respuesta);
        }
    }

    protected virtual string ObtenerIdDeCorrelacion()
    {
        return Guid.NewGuid().ToString();
    }

    protected virtual Dictionary<string, string> ObtenerEncabezadosIniciales(string idDeCorrelacion,
                                                                            string? encabezadoDeAutorizacion)
    {
        Dictionary<string, string> encabezados = new()
        {
            ["correlationId"] = idDeCorrelacion
        };

        if (!string.IsNullOrWhiteSpace(encabezadoDeAutorizacion))
        {
            encabezados["Authorization"] = encabezadoDeAutorizacion;
        }

        return encabezados;
    }
}
