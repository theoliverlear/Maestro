namespace Maestro.Excepción;

public class ExcepciónDeSerializaciónFallida : Exception
{
    public static string Mensaje = "La serialización ha fallado para:\n";

    public ExcepciónDeSerializaciónFallida(Object objeto) : base(Mensaje + objeto)
    {

    }
}