using System.Net;

namespace Maestro.Biblioteca.Universal.Modelos;

public class RespuestaConEstado<TCarga>
{
    public TCarga Carga { get; set; }
    public HttpStatusCode Estado { get; set; }

    public RespuestaConEstado(TCarga carga, HttpStatusCode estado)
    {
        this.Carga = carga;
        this.Estado = estado;
    }
}
