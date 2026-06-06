namespace Maestro.Biblioteca.Api.Comunicación.Respuesta.Operaciones;

public class RespuestaDeÉxitoDeOperación
{
    public bool OperaciónExitosa { get; set; }
    public string Mensaje { get; set; }

    public RespuestaDeÉxitoDeOperación(bool operaciónExitosa, string mensaje)
    {
        this.OperaciónExitosa = operaciónExitosa;
        this.Mensaje = mensaje;
    }
}
