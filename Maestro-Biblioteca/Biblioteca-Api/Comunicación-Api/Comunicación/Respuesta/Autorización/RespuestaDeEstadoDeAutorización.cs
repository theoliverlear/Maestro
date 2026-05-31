namespace Maestro.Comunicación.Respuesta.Autorización;

public class RespuestaDeEstadoDeAutorización
{
    public bool EsAutorizado { get; private set; }

    public RespuestaDeEstadoDeAutorización(bool esAutorizado)
    {
        this.EsAutorizado = esAutorizado;
    }
}
