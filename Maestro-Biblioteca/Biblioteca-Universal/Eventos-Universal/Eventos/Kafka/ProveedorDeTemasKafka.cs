using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Maestro.Biblioteca.Universal.Eventos.Configuracion;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Maestro.Biblioteca.Universal.Eventos.Kafka;

public class ProveedorDeTemasKafka
{
    private readonly OpcionesDeKafka _opciones;
    private readonly ILogger<ProveedorDeTemasKafka> _log;

    public ProveedorDeTemasKafka(IOptions<OpcionesDeKafka> opciones,
                                 ILogger<ProveedorDeTemasKafka> log)
    {
        this._opciones = opciones.Value;
        this._log = log;
    }

    public async Task AsegurarTemaAsync(string tema, CancellationToken ct = default)
    {
        if (!this._opciones.CrearTemasAutomaticamente)
        {
            return;
        }

        AdminClientConfig config = new()
        {
            BootstrapServers = this._opciones.ServidoresBootstrap,
            ClientId = $"{this._opciones.IdDeCliente}-admin"
        };

        using IAdminClient admin = new AdminClientBuilder(config).Build();
        try
        {
            await admin.CreateTopicsAsync(
                [
                    new TopicSpecification
                    {
                        Name = tema,
                        NumPartitions = this._opciones.ParticionesPredeterminadas,
                        ReplicationFactor = this._opciones.FactorDeReplicacionPredeterminado
                    }
                ]);
            this._log.LogInformation("Tema Kafka creado: {Tema}.", tema);
        }
        catch (CreateTopicsException excepcion)
            when (excepcion.Results.All(resultado => resultado.Error.Code == ErrorCode.TopicAlreadyExists))
        {
            this._log.LogDebug("Tema Kafka ya existe: {Tema}.", tema);
        }
        catch (CreateTopicsException excepcion)
        {
            if (excepcion.Results.Any(resultado => resultado.Error.Code != ErrorCode.TopicAlreadyExists))
            {
                throw;
            }
        }
    }
}
