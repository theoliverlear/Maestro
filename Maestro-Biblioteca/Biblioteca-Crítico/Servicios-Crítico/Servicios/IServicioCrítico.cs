using Maestro.Biblioteca.Crítico.Comunicación.Respuesta;
using Maestro.Biblioteca.Crítico.Comunicación.Solicitud;

namespace Maestro.Biblioteca.Crítico.Servicios;

public interface IServicioCrítico
{
    Task<RespuestaCrítico> ProcesarAsync(SolicitudCrítico solicitud,
                                         string? encabezadoDeAutorizacion,
                                         CancellationToken ct = default);
}
