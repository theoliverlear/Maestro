namespace Maestro.Biblioteca.Api.Entidad.Conjugación.Propiedades;

public class ÁnimoInglés
{
    public string CadenaDeÁnimoInglés { get; }

    public static readonly ÁnimoInglés Subjunctive = new("Subjunctive");
    public static readonly ÁnimoInglés ImperativeNegative = new("Imperative Negative");
    public static readonly ÁnimoInglés ImperativeAffirmative = new("Imperative Affirmative");
    public static readonly ÁnimoInglés Indicative = new("Indicative");


    public static readonly List<ÁnimoInglés> ÁnimosInglés = new()
    {
        Subjunctive, ImperativeNegative, ImperativeAffirmative, Indicative
    };
    
    public ÁnimoInglés(string cadenaDeÁnimoInglés)
    {
        this.CadenaDeÁnimoInglés = cadenaDeÁnimoInglés;
    }

    public static ÁnimoInglés DeCuerda(string cadenaDeÁnimoInglés)
    {
        foreach (ÁnimoInglés ánimoInglés in ÁnimosInglés)
        {
            if (string.Equals(
                    ánimoInglés.CadenaDeÁnimoInglés,
                    cadenaDeÁnimoInglés.Trim(),
                    StringComparison.OrdinalIgnoreCase))
            {
                return ánimoInglés;
            }
        }

        throw new ArgumentException(
            "Ánimo en inglés no reconocido.",
            nameof(cadenaDeÁnimoInglés));
    }
}
