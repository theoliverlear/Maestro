namespace Maestro.Biblioteca.Universal.Eventos.Configuración;

public class OpcionesDeKafka
{
    public const string Seccion = "Kafka";

    public string ServidoresBootstrap { get; set; } = "localhost:9092";
    public string IdDeCliente { get; set; } = "maestro";
    public string GrupoDeConsumidor { get; set; } = "maestro";
    public bool CrearTemasAutomaticamente { get; set; } = true;
    public int ParticionesPredeterminadas { get; set; } = 1;
    public short FactorDeReplicacionPredeterminado { get; set; } = 1;
    public Dictionary<string, OpcionesDeEnlaceKafka> Enlaces { get; set; } = new();

    public string ResolverDestino(string nombreDeEnlace)
    {
        if (this.Enlaces.TryGetValue(nombreDeEnlace, out OpcionesDeEnlaceKafka? enlace) &&
            !string.IsNullOrWhiteSpace(enlace.Destino))
        {
            return enlace.Destino;
        }

        return nombreDeEnlace;
    }

    public string ResolverGrupoDeConsumidor(string nombreDeEnlace)
    {
        if (this.Enlaces.TryGetValue(nombreDeEnlace, out OpcionesDeEnlaceKafka? enlace) &&
            !string.IsNullOrWhiteSpace(enlace.Grupo))
        {
            return enlace.Grupo;
        }

        return this.GrupoDeConsumidor;
    }
}

public class OpcionesDeEnlaceKafka
{
    public string Destino { get; set; } = string.Empty;
    public string? Grupo { get; set; }
    public string TipoDeContenido { get; set; } = "application/json";
}
