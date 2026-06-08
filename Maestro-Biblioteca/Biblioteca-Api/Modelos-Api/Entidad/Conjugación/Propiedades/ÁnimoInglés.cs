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
        CadenaDeÁnimoInglés = cadenaDeÁnimoInglés;
    }
}