namespace Maestro.Modelos.Operaciones;

public class EstadoDeOperación
{
    public bool OperaciónExitosa { get; set; }
    public string Mensaje { get; set; }
    public static readonly EstadoDeOperación ÉxitoDeOperación = new(true, "Éxito de la operación.");
    public static readonly EstadoDeOperación OperaciónFallida = new(false, "Operación fallida.");
    public static readonly EstadoDeOperación OperaciónDenegada = new(false, "Operación denegada.");

    private EstadoDeOperación(bool operaciónExitosa, string mensaje)
    {
        this.OperaciónExitosa = operaciónExitosa;
        this.Mensaje = mensaje;
    }
}