using Maestro.Modelos.Autorización;

namespace Maestro.Comunicación.Respuesta.Autorización;

public class RespuestaDeEstadoDeAutorización
{
    public bool EsAutorizado { get; private set; }
    public RespuestaDeEstadoDeAutorización(EstadoDeAutorización estado)
    {
        this.EsAutorizado = estado.EsAutorizado;
    }
}