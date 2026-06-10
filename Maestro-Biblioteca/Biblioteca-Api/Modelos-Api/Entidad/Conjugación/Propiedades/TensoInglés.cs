namespace Maestro.Biblioteca.Api.Entidad.Conjugación.Propiedades;

public class TensoInglés
{
    public string CadenaDeTensoInglés { get; }

    public static readonly TensoInglés Future = new("Future");
    public static readonly TensoInglés Present = new("Present");
    public static readonly TensoInglés PresentPerfect = new("Present Perfect");
    public static readonly TensoInglés ConditionalPerfect = new("Conditional Perfect");
    public static readonly TensoInglés Imperfect = new("Imperfect");
    public static readonly TensoInglés PastPerfect = new("Past Perfect");
    public static readonly TensoInglés Preterite = new("Preterite");
    public static readonly TensoInglés Conditional = new("Conditional");
    public static readonly TensoInglés PreteriteArchaic = new("Preterite (Archaic)");
    public static readonly TensoInglés FuturePerfect = new("Future Perfect");

        public static readonly List<TensoInglés> TensosInglés = new()
        {
            Future, Present, PresentPerfect, ConditionalPerfect, Imperfect,
            PastPerfect, Preterite, Conditional, PreteriteArchaic,
            FuturePerfect
        };

    public TensoInglés(string cadenaDeTensoInglés)
    {
        this.CadenaDeTensoInglés = cadenaDeTensoInglés;
    }

    public static TensoInglés DeCuerda(string cadenaDeTensoInglés)
    {
        foreach (TensoInglés tensoInglés in TensosInglés)
        {
            if (string.Equals(
                    tensoInglés.CadenaDeTensoInglés,
                    cadenaDeTensoInglés.Trim(),
                    StringComparison.OrdinalIgnoreCase))
            {
                return tensoInglés;
            }
        }

        throw new ArgumentException(
            "Tenso en inglés no reconocido.",
            nameof(cadenaDeTensoInglés));
    }
}
