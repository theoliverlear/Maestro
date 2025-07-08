using CsvHelper.Configuration.Attributes;

namespace Maestro.Modelos.Conjugación.Diccionario;

public class FilaDeConjugación
{
    [Name("infinitive")]
    public string Infinitivo { get; init; } = null!;

    [Name("infinitive_english")]
    public string InfinitivoEnInglés { get; init; } = null!;

    [Name("mood")]
    public string Ánimo { get; init; } = null!;
    [Name("mood_english")]
    public string ÁnimoEnInglés { get; init; } = null!;
    [Name("tense")]
    public string Tenso { get; init; } = null!;
    [Name("tense_english")]
    public string TensoEnInglés { get; init; } = null!;

    [Name("form_1s")]
    public string Yo { get; init; } = null!;
    [Name("form_2s")]
    public string Tú { get; init; } = null!;
    [Name("form_3s")]
    public string Él { get; init; } = null!;
    [Name("form_1p")]
    public string Nosotros { get; init; } = null!;
    [Name("form_2p")]
    public string Vosotros { get; init; } = null!;
    [Name("form_3p")]
    public string Ellos { get; init; } = null!;

    [Name("verb_english")]
    public string VerboInglés { get; init; } = null!;
    [Name("gerund")]
    public string Gerundio { get; init; } = null!;
    [Name("gerund_english")]
    public string GerundioEnInglés { get; init; } = null!;
    [Name("pastparticiple")]
    public string ParticipioPasado { get; init; } = null!;
    [Name("pastparticiple_english")]
    public string ParticipioPasadoEnInglés { get; init; } = null!;
}