using System.Text;
using System.Text.Json;
using Confluent.Kafka;
using Maestro.Biblioteca.Universal.Eventos.Configuración;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Maestro.Biblioteca.Universal.Eventos.Kafka;

public class PublicadorKafkaDeEventos : IPublicadorDeEventos, IDisposable
{
    private static readonly JsonSerializerOptions OpcionesJson = new(JsonSerializerDefaults.Web);

    private readonly IProducer<string, string> _productor;
    private readonly OpcionesDeKafka _opciones;
    private readonly ProveedorDeTemasKafka _proveedorDeTemas;
    private readonly ILogger<PublicadorKafkaDeEventos> _log;

    public PublicadorKafkaDeEventos(IOptions<OpcionesDeKafka> opciones,
                                    ProveedorDeTemasKafka proveedorDeTemas,
                                    ILogger<PublicadorKafkaDeEventos> log)
    {
        OpcionesDeKafka opcionesDeKafka = opciones.Value;
        this._opciones = opcionesDeKafka;
        ProducerConfig configuracion = new()
        {
            BootstrapServers = opcionesDeKafka.ServidoresBootstrap,
            ClientId = opcionesDeKafka.IdDeCliente,
            Acks = Acks.All,
            EnableIdempotence = true,
            AllowAutoCreateTopics = opcionesDeKafka.CrearTemasAutomaticamente
        };

        this._productor = new ProducerBuilder<string, string>(configuracion).Build();
        this._proveedorDeTemas = proveedorDeTemas;
        this._log = log;
    }

    public async Task<bool> PublicarAsync<TCarga>(string nombreDeEnlace,
                                                  TCarga carga,
                                                  IReadOnlyDictionary<string, string>? encabezados = null,
                                                  CancellationToken ct = default)
    {
        string cuerpo = JsonSerializer.Serialize(carga, OpcionesJson);
        Message<string, string> mensaje = new()
        {
            Key = ObtenerClave(encabezados),
            Value = cuerpo,
            Headers = CrearEncabezados(encabezados)
        };

        string destino = this._opciones.ResolverDestino(nombreDeEnlace);
        await this._proveedorDeTemas.AsegurarTemaAsync(destino, ct);
        this._log.LogDebug("Publicando evento Kafka {NombreDeEnlace} en {Destino}.", nombreDeEnlace, destino);
        DeliveryResult<string, string> resultado = await this._productor.ProduceAsync(destino, mensaje, ct);
        return resultado.Status is PersistenceStatus.Persisted or PersistenceStatus.PossiblyPersisted;
    }

    public void Dispose()
    {
        this._productor.Flush(TimeSpan.FromSeconds(5));
        this._productor.Dispose();
    }

    private static string ObtenerClave(IReadOnlyDictionary<string, string>? encabezados)
    {
        if (encabezados != null && encabezados.TryGetValue("correlationId", out string? idDeCorrelacion))
        {
            return idDeCorrelacion;
        }

        return string.Empty;
    }

    private static Headers CrearEncabezados(IReadOnlyDictionary<string, string>? encabezados)
    {
        Headers headers = new();
        if (encabezados == null)
        {
            return headers;
        }

        foreach (KeyValuePair<string, string> encabezado in encabezados)
        {
            headers.Add(encabezado.Key, Encoding.UTF8.GetBytes(encabezado.Value));
        }

        return headers;
    }
}
