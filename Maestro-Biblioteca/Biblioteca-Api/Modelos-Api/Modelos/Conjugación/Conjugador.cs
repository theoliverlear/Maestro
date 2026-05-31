using Maestro.Modelos.Conjugación.Diccionario;

namespace Maestro.Modelos.Conjugación;

public class Conjugador
{

    public static string Conjugado(string verbo = "",
                                   string ánimo = "Indicativo",
                                   string tenso = "Presente",
                                   string pronombre = "Yo")
    {
        return DiccionarioDeConjugación.Constructor()
                                       .ConVerbo(verbo)
                                       .ConÁnimo(ánimo)
                                       .ConTenso(tenso)
                                       .ConPronombre(pronombre)
                                       .Construir();
    }

    public static string ConjugarSoloConVerbo(string verbo)
    {
        return Conjugado(verbo: verbo);
    }

    public static string ConjugarConVerboPronombre(string verbo, string pronombre)
    {
        return Conjugado(verbo: verbo, pronombre: pronombre);
    }

    public static string ConjugarConVerboPronombre(string verbo, Pronombre pronombre)
    {
        return ConjugarConVerboPronombre(verbo, pronombre.Sujeto);
    }

    public static string ConjugarConVerboPronombreÁnimo(string verbo,
                                                        string pronombre,
                                                        string ánimo)
    {
        return Conjugado(verbo: verbo, pronombre: pronombre, ánimo: ánimo);
    }
}