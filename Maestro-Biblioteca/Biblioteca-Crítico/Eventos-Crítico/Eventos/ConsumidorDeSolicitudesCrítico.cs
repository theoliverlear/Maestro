using Maestro.Biblioteca.Crítico.Comunicacion.Respuesta;
using Maestro.Biblioteca.Crítico.Comunicacion.Solicitud;
using Maestro.Biblioteca.Crítico.Servicios;
using Maestro.Biblioteca.Universal.Eventos;
using Maestro.Biblioteca.Universal.Eventos.Configuracion;
using Maestro.Biblioteca.Universal.Eventos.Kafka;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Maestro.Biblioteca.Crítico.Eventos;

public class ConsumidorDeSolicitudesCrítico :
    ConsumidorKafkaDeEventosBase<SolicitudCrítico, RespuestaCrítico>
{
    private readonly IServicioCrítico _servicio;

    public ConsumidorDeSolicitudesCrítico(IOptions<OpcionesDeKafka> opciones,
                                          IPublicadorDeEventos publicador,
                                          ProveedorDeTemasKafka proveedorDeTemas,
                                          IServicioCrítico servicio,
                                          ILogger<ConsumidorDeSolicitudesCrítico> log)
        : base(opciones,
               publicador,
               proveedorDeTemas,
               EnlacesCrítico.SolicitudesEntrantes.NombreDeEnlace,
               EnlacesCrítico.Respuestas.NombreDeEnlace,
               log)
    {
        this._servicio = servicio;
    }

    protected override Task<RespuestaCrítico> ProcesarAsync(SolicitudCrítico solicitud,
                                                            string? encabezadoDeAutorizacion,
                                                            CancellationToken ct)
    {
        return this._servicio.ProcesarAsync(solicitud, encabezadoDeAutorizacion, ct);
    }

    protected override RespuestaCrítico ManejarError(Exception excepcion)
    {
        return RespuestaCrítico.Error(excepcion.Message);
    }
}
