namespace Maestro.Biblioteca.Api.Entidad.Conjugación.Propiedades;

public class Ánimo
{
    public static readonly Ánimo ImperativoAfirmativo = new("Imperativo Afirmativo");
    public static readonly Ánimo Indicativo = new("Indicativo");
    public static readonly Ánimo ImperativoNegativo = new("Imperativo Negativo");
    public static readonly Ánimo Subjuntivo = new("Subjuntivo");

    public string CadenaDeÁnimo { get; }

    public static readonly List<Ánimo> Ánimos = new()
    {
        ImperativoAfirmativo, Indicativo, ImperativoNegativo, Subjuntivo
    };

    public Ánimo(string cadenaDeÁnimo)
    {
        this.CadenaDeÁnimo = cadenaDeÁnimo;
    }

    public static Ánimo DeCuerda(string cadenaDeÁnimo)
    {
        foreach (Ánimo ánimo in Ánimos)
        {
            if (string.Equals(
                    ánimo.CadenaDeÁnimo,
                    cadenaDeÁnimo.Trim(),
                    StringComparison.OrdinalIgnoreCase))
            {
                return ánimo;
            }
        }

        throw new ArgumentException("Ánimo no reconocido.", nameof(cadenaDeÁnimo));
    }
}
