using Maestro.Modelos.Operaciones;

namespace Maestro.Comunicación.Respuesta.Operaciones;

public class RespuestaDeÉxitoDeOperación
{
    public bool OperaciónExitosa { get; set; }
    public string Mensaje { get; set; }

    public RespuestaDeÉxitoDeOperación(EstadoDeOperación estado)
    {
        this.OperaciónExitosa = estado.OperaciónExitosa;
        this.Mensaje = estado.Mensaje;
    }
}