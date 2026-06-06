namespace Maestro.Biblioteca.Api.Modelos.Excepción;

public class ExcepciónDeVerboNoAdmitidos : Exception
{
    public static string Mensaje = "Este verbo no está soportado en el" +
                                   " diccionario de Maestro: ";

    public ExcepciónDeVerboNoAdmitidos(string verbo) : base(Mensaje + verbo)
    {

    }
}