using Maestro.Biblioteca.Traducción.Comunicación.Respuesta;
using Maestro.Biblioteca.Traducción.Comunicación.Solicitud;

namespace Maestro.Biblioteca.Traducción.Servicios;

public interface IServicioTraducción
{
    Task<RespuestaTraducción> ProcesarAsync(SolicitudTraducción solicitud,
                                            string? encabezadoDeAutorizacion,
                                            CancellationToken ct = default);
}
