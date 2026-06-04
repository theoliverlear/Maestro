namespace Maestro.Biblioteca.Universal.Eventos;

public interface IComunicadorDeSolicitud<TSolicitud, TRespuesta>
{
    Task<TRespuesta> EjecutarAsync(IEnlaceDeEvento enlace,
                                   TSolicitud solicitud,
                                   CancellationToken ct = default);

    Task<TRespuesta> EjecutarAsync(IEnlaceDeEvento enlace,
                                   TSolicitud solicitud,
                                   TimeSpan esperaMaxima,
                                   CancellationToken ct = default);

    Task<TRespuesta> EjecutarAsync(IEnlaceDeEvento enlace,
                                   TSolicitud solicitud,
                                   TimeSpan esperaMaxima,
                                   string? encabezadoDeAutorizacion,
                                   CancellationToken ct = default);
}
