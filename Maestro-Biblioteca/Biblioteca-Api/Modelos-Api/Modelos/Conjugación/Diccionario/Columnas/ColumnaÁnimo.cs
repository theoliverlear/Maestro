namespace Maestro.Biblioteca.Api.Modelos.Conjugación.Diccionario.Columnas;

public class ColumnaÁnimo
{
    public string CadenaDeÁnimo { get; }
    public static readonly ColumnaÁnimo Indicativo = new("Indicativo");
    public static readonly ColumnaÁnimo Subjuntivo = new("Subjuntivo");
    public static readonly ColumnaÁnimo Imperativo = new("Imperativo");

    public static readonly List<ColumnaÁnimo> EstadosDeÁnimo = new()
    {
        Indicativo, Subjuntivo, Imperativo
    };

    private ColumnaÁnimo(string ánimo)
    {
        this.CadenaDeÁnimo = ánimo;
    }

    public static ColumnaÁnimo DeCuerda(string ánimo)
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