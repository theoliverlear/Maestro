using Maestro.Biblioteca.Crítico.Comunicacion.Respuesta;
using Maestro.Biblioteca.Crítico.Comunicacion.Solicitud;

namespace Maestro.Biblioteca.Crítico.Servicios;

public interface IServicioCrítico
{
    Task<RespuestaCrítico> ProcesarAsync(SolicitudCrítico solicitud,
                                         string? encabezadoDeAutorizacion,
                                         CancellationToken ct = default);
}
