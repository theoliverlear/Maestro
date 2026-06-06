using Maestro.Biblioteca.Traducción.Comunicación.Respuesta;
using Maestro.Biblioteca.Traducción.Comunicación.Solicitud;
using Maestro.Biblioteca.Traducción.Servicios;
using Maestro.Biblioteca.Universal.Eventos;
using Maestro.Biblioteca.Universal.Eventos.Configuración;
using Maestro.Biblioteca.Universal.Eventos.Kafka;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Maestro.Biblioteca.Traducción.Eventos;

public class ConsumidorDeSolicitudesTraducción :
    ConsumidorKafkaDeEventosBase<SolicitudTraducción, RespuestaTraducción>
{
    private readonly IServicioTraducción _servicio;

    public ConsumidorDeSolicitudesTraducción(IOptions<OpcionesDeKafka> opciones,
                                             IPublicadorDeEventos publicador,
                                             ProveedorDeTemasKafka proveedorDeTemas,
                                             IServicioTraducción servicio,
                                             ILogger<ConsumidorDeSolicitudesTraducción> log)
        : base(opciones,
               publicador,
               proveedorDeTemas,
               EnlacesTraducción.SolicitudesEntrantes.NombreDeEnlace,
               EnlacesTraducción.Respuestas.NombreDeEnlace,
               log)
    {
        this._servicio = servicio;
    }

    protected override Task<RespuestaTraducción> ProcesarAsync(SolicitudTraducción solicitud,
                                                               string? encabezadoDeAutorizacion,
                                                               CancellationToken ct)
    {
        return this._servicio.ProcesarAsync(solicitud, encabezadoDeAutorizacion, ct);
    }

    protected override RespuestaTraducción ManejarError(Exception excepcion)
    {
        return new RespuestaTraducción($"No se pudo traducir el texto: {excepcion.Message}");
    }
}
