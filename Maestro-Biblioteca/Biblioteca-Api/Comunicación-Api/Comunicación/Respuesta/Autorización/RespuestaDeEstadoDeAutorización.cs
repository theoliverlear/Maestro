using System.Text.Json.Serialization;

namespace Maestro.Biblioteca.Api.Comunicación.Respuesta.Autorización;

public class RespuestaDeEstadoDeAutorización
{
    public bool EsAutorizado { get; private set; }
    public string? Token { get; private set; }
    [JsonIgnore]
    public string? IdDeTokenDeActualización { get; private set; }
    [JsonIgnore]
    public DateTimeOffset? ExpiraTokenDeActualizaciónEn { get; private set; }

    public RespuestaDeEstadoDeAutorización(bool esAutorizado,
                                           string? token = null,
                                           string? idDeTokenDeActualización = null,
                                           DateTimeOffset? expiraTokenDeActualizaciónEn = null)
    {
        this.EsAutorizado = esAutorizado;
        this.Token = token;
        this.IdDeTokenDeActualización = idDeTokenDeActualización;
        this.ExpiraTokenDeActualizaciónEn = expiraTokenDeActualizaciónEn;
    }
}
