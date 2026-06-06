namespace Maestro.Biblioteca.Api.Modelos.Excepción;

public class ExcepciónDeTensoNoAdmitidos : Exception
{
    public static string Mensaje = "Este tenso no está soportado en el " +
                                    "diccionario de Maestro: ";

    public ExcepciónDeTensoNoAdmitidos(string tenso) : base(Mensaje + tenso)
    {

    }
}