namespace Maestro.Excepción;

public class ExcepciónDeVerboNoAdmitido : Exception
{
    public static string Mensaje = "Este verbo no está soportado en el" +
                                   " diccionario de Maestro: ";

    public ExcepciónDeVerboNoAdmitido(string verbo) : base(Mensaje + verbo)
    {

    }
}