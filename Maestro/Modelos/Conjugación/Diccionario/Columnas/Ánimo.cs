namespace Maestro.Modelos.Conjugación.Diccionario.Columnas;

public class Ánimo
{
    public string CadenaDeÁnimo { get; set; }
    public static readonly Ánimo Indicativo = new("Indicativo");
    public static readonly Ánimo Subjuntivo = new("Subjuntivo");
    public static readonly Ánimo Imperativo = new("Imperativo");

    public static readonly List<Ánimo> EstadosDeÁnimo = new()
    {
        Indicativo, Subjuntivo, Imperativo
    };

    private Ánimo(string ánimo)
    {
        this.CadenaDeÁnimo = ánimo;
    }

    public static Ánimo DeCuerda(string ánimo)
    {
        ánimo = ánimo[0].ToString().ToUpper() + ánimo[1..].ToLower();
        return ánimo switch
        {
            "Indicativo" => Indicativo,
            "Subjuntivo" => Subjuntivo,
            "Imperativo" => Imperativo,
            _ => throw new ArgumentException("Ánimo no reconocido.", nameof(ánimo))
        };
    }
}