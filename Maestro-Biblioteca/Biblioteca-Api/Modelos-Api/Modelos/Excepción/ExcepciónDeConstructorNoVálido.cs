namespace Maestro.Excepción;

public class ExcepciónDeConstructorNoVálido : Exception
{
    public static string Mensaje = "El generador de objetos está " +
                                   "incompleto o mal formado.";

    public ExcepciónDeConstructorNoVálido() : base(Mensaje)
    {

    }
}