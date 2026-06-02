using System.Text;
using System.Text.Json;
using Confluent.Kafka;
using Maestro.Biblioteca.Crítico.Comunicacion.Respuesta;
using Maestro.Biblioteca.Universal.Eventos.Configuracion;
using Maestro.Biblioteca.Universal.Eventos.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Maestro.Biblioteca.Crítico.Eventos;

public class ConsumidorDeRespuestasCrítico : BackgroundService
{
    private static readonly JsonSerializerOptions OpcionesJson = new(JsonSerializerDefaults.Web);

    private readonly ComunicadorCrítico _comunicador;
    private readonly IConsumer<string, string> _consumidor;
    private readonly ProveedorDeTemasKafka _proveedorDeTemas;
    private readonly string _destino;
    private readonly ILogger<ConsumidorDeRespuestasCrítico> _log;

    public ConsumidorDeRespuestasCrítico(IOptions<OpcionesDeKafka> opciones,
                                         ComunicadorCrítico comunicador,
                                         ProveedorDeTemasKafka proveedorDeTemas,
                                         ILogger<ConsumidorDeRespuestasCrítico> log)
    {
        OpcionesDeKafka opcionesDeKafka = opciones.Value;
        string enlace = EnlacesCrítico.RespuestasEntrantes.NombreDeEnlace;
        this._destino = opcionesDeKafka.ResolverDestino(enlace);
        this._comunicador = comunicador;
        this._proveedorDeTemas = proveedorDeTemas;
        this._log = log;
        ConsumerConfig config = new()
        {
            BootstrapServers = opcionesDeKafka.ServidoresBootstrap,
            GroupId = opcionesDeKafka.ResolverGrupoDeConsumidor(enlace),
            ClientId = opcionesDeKafka.IdDeCliente,
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false,
            AllowAutoCreateTopics = opcionesDeKafka.CrearTemasAutomaticamente
        };
        this._consumidor = new ConsumerBuilder<string, string>(config).Build();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await this._proveedorDeTemas.AsegurarTemaAsync(this._destino, stoppingToken);
        await Task.Run(() => this.Consumir(stoppingToken), stoppingToken);
    }

    public override void Dispose()
    {
        this._consumidor.Dispose();
        base.Dispose();
    }

    private void Consumir(CancellationToken ct)
    {
        this._consumidor.Subscribe(this._destino);
        this._log.LogInformation("Consumiendo respuestas de Crítico desde {Destino}.", this._destino);
        try
        {
            while (!ct.IsCancellationRequested)
            {
                ConsumeResult<string, string> resultado = this._consumidor.Consume(ct);
                this.ManejarResultado(resultado);
                this._consumidor.Commit(resultado);
            }
        }
        catch (OperationCanceledException) when (ct.IsCancellationRequested)
        {
        }
        finally
        {
            this._consumidor.Close();
        }
    }

    private void ManejarResultado(ConsumeResult<string, string> resultado)
    {
        string? idDeCorrelación = LeerEncabezado(resultado.Message.Headers, "correlationId");
        RespuestaCrítico? respuesta = JsonSerializer.Deserialize<RespuestaCrítico>(resultado.Message.Value, OpcionesJson);
        if (respuesta == null)
        {
            this._log.LogWarning("Respuesta de Crítico vacía para correlationId={IdDeCorrelación}.", idDeCorrelación);
            return;
        }

        this._log.LogDebug("Despachando respuesta de Crítico correlationId={IdDeCorrelación}.", idDeCorrelación);
        this._comunicador.ManejarRespuesta(idDeCorrelación, respuesta);
    }

    private static string? LeerEncabezado(Headers headers, string llave)
    {
        IHeader? encabezado = headers.FirstOrDefault(header => header.Key == llave);
        return encabezado == null ? null : Encoding.UTF8.GetString(encabezado.GetValueBytes());
    }
}
