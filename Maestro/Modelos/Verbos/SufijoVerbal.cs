namespace Maestro.Modelos.Verbos;

public class SufijoVerbal
{
    private string sufijo;
    public static readonly SufijoVerbal Ar = new("ar");
    public static readonly SufijoVerbal Er = new("er");
    public static readonly SufijoVerbal Ir = new("ir");

    public static readonly List<SufijoVerbal> Sufijos =
    [
        Ar, Er, Ir
    ];

    private static string mensajeDeVerboInválido = "El verbo debe tener al" +
                                                   " menos dos caracteres.";
    private static string mensajeDeSufijoNoEncontrado = "No se encontró un " +
                                                        "sufijo válido para" +
                                                        " el verbo proporcionado.";

    public SufijoVerbal(string sufijo)
    {
        this.sufijo = sufijo;
    }

    public static SufijoVerbal ObtenerSufijo(string verbo)
    {
        if (verbo.Length < 2)
        {
            throw new ArgumentException(mensajeDeVerboInválido);
        }

        foreach (SufijoVerbal sufijo in Sufijos)
        {
            if (verbo.EndsWith(sufijo.Sufijo))
            {
                return sufijo;
            }
        }
        throw new ArgumentException(mensajeDeSufijoNoEncontrado);
    }

    public override int GetHashCode()
    {
        return this.sufijo.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is not SufijoVerbal sufijoVerbal)
        {
            return false;
        }
        return this.sufijo == sufijoVerbal.sufijo;
    }

    public string Sufijo
    {
        get => this.sufijo;
        set => this.sufijo = value;
    }
}