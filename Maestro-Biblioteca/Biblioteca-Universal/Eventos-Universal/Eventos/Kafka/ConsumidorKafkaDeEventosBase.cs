using System.Text;
using System.Text.Json;
using Confluent.Kafka;
using Maestro.Biblioteca.Universal.Eventos.Configuracion;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Maestro.Biblioteca.Universal.Eventos.Kafka;

public abstract class ConsumidorKafkaDeEventosBase<TSolicitud, TRespuesta> : BackgroundService
{
    private static readonly JsonSerializerOptions OpcionesJson = new(JsonSerializerDefaults.Web);

    private readonly IPublicadorDeEventos _publicadorDeEventos;
    private readonly IConsumer<string, string> _consumidor;
    private readonly ProveedorDeTemasKafka _proveedorDeTemas;
    private readonly string _enlaceDeEntrada;
    private readonly string _enlaceDeSalida;
    private readonly ILogger _log;

    protected ConsumidorKafkaDeEventosBase(IOptions<OpcionesDeKafka> opciones,
                                           IPublicadorDeEventos publicadorDeEventos,
                                           ProveedorDeTemasKafka proveedorDeTemas,
                                           string enlaceDeEntrada,
                                           string enlaceDeSalida,
                                           ILogger log)
    {
        OpcionesDeKafka opcionesDeKafka = opciones.Value;
        string destinoDeEntrada = opcionesDeKafka.ResolverDestino(enlaceDeEntrada);
        ConsumerConfig configuracion = new()
        {
            BootstrapServers = opcionesDeKafka.ServidoresBootstrap,
            GroupId = opcionesDeKafka.ResolverGrupoDeConsumidor(enlaceDeEntrada),
            ClientId = opcionesDeKafka.IdDeCliente,
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false,
            AllowAutoCreateTopics = opcionesDeKafka.CrearTemasAutomaticamente
        };

        this._consumidor = new ConsumerBuilder<string, string>(configuracion).Build();
        this._publicadorDeEventos = publicadorDeEventos;
        this._proveedorDeTemas = proveedorDeTemas;
        this._enlaceDeEntrada = destinoDeEntrada;
        this._enlaceDeSalida = enlaceDeSalida;
        this._log = log;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await this._proveedorDeTemas.AsegurarTemaAsync(this._enlaceDeEntrada, stoppingToken);
        this._consumidor.Subscribe(this._enlaceDeEntrada);
        this._log.LogInformation("Consumiendo eventos Kafka desde {EnlaceDeEntrada}.", this._enlaceDeEntrada);

        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                ConsumeResult<string, string> resultado = this._consumidor.Consume(stoppingToken);
                await this.ManejarResultadoAsync(resultado, stoppingToken);
                this._consumidor.Commit(resultado);
            }
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
        }
        finally
        {
            this._consumidor.Close();
        }
    }

    public override void Dispose()
    {
        this._consumidor.Dispose();
        base.Dispose();
    }

    protected abstract Task<TRespuesta> ProcesarAsync(TSolicitud solicitud,
                                                      string? encabezadoDeAutorizacion,
                                                      CancellationToken ct);

    protected abstract TRespuesta ManejarError(Exception excepcion);

    private async Task ManejarResultadoAsync(ConsumeResult<string, string> resultado, CancellationToken ct)
    {
        IReadOnlyDictionary<string, string> encabezados = LeerEncabezados(resultado.Message.Headers);
        encabezados.TryGetValue("correlationId", out string? idDeCorrelacion);
        encabezados.TryGetValue("Authorization", out string? autorizacion);
        this._log.LogDebug("Procesando evento Kafka correlationId={IdDeCorrelacion}.", idDeCorrelacion);

        TRespuesta respuesta;
        try
        {
            TSolicitud solicitud = JsonSerializer.Deserialize<TSolicitud>(resultado.Message.Value, OpcionesJson)
                                   ?? throw new JsonException("No se pudo deserializar la solicitud Kafka.");
            respuesta = await this.ProcesarAsync(solicitud, autorizacion, ct);
        }
        catch (Exception excepcion)
        {
            this._log.LogError(excepcion, "Error procesando evento Kafka correlationId={IdDeCorrelacion}.", idDeCorrelacion);
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

    private static IReadOnlyDictionary<string, string> LeerEncabezados(Headers? headers)
    {
        Dictionary<string, string> encabezados = new();
        if (headers == null)
        {
            return encabezados;
        }

        foreach (Header header in headers)
        {
            encabezados[header.Key] = Encoding.UTF8.GetString(header.GetValueBytes());
        }

        return encabezados;
    }
}
