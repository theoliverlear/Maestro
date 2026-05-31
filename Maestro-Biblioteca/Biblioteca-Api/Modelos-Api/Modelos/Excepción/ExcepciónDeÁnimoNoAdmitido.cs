namespace Maestro.Excepción;

public class ExcepciónDeÁnimoNoAdmitido : Exception
{
    public static string Mensaje = "Este ánimo no está soportado en el " +
                                    "diccionario de Maestro: ";

    public ExcepciónDeÁnimoNoAdmitido(string ánimo) : base(Mensaje + ánimo)
    {

    }
}