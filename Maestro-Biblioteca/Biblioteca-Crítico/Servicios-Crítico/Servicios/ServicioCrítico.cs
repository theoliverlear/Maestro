using Maestro.Biblioteca.Crítico.Comunicación.Respuesta;
using Maestro.Biblioteca.Crítico.Comunicación.Solicitud;

namespace Maestro.Biblioteca.Crítico.Servicios;

public class ServicioCrítico : IServicioCrítico
{
    public Task<RespuestaCrítico> ProcesarAsync(SolicitudCrítico solicitud,
                                                string? encabezadoDeAutorizacion,
                                                CancellationToken ct = default)
    {
        RespuestaCrítico respuesta = RespuestaCrítico.Correcta(
            solicitud.CargaJson,
            "Crítico conectado al bus de eventos.");
        return Task.FromResult(respuesta);
    }
}
