namespace Maestro.Modelos.Conjugación.Diccionario.Columnas;

public class Tenso
{
    public string CadenaDeTenso { get; set; }
    public static readonly Tenso Presente = new("Presente");
    public static readonly Tenso Futuro = new("Futuro");
    public static readonly Tenso Imperfecto = new("Imperfecto");
    public static readonly Tenso Pretérito = new("Pretérito");
    public static readonly Tenso Condicional = new("Condicional");
    public static readonly Tenso PresentePerfecto = new("Presente perfecto");
    public static readonly Tenso FuturoPerfecto = new("Futuro perfecto");
    public static readonly Tenso Pluscuamperfecto = new("Pluscuamperfecto");
    public static readonly Tenso PretéritoAnterior = new("Pretérito anterior");
    public static readonly Tenso CondicionalPerfecto = new("Condicional perfecto");

    public static readonly List<Tenso> TiemposVerbales = new()
    {
        Presente, Futuro, Imperfecto, Pretérito, Condicional,
        PresentePerfecto, FuturoPerfecto, Pluscuamperfecto, PretéritoAnterior,
        CondicionalPerfecto
    };

    private Tenso(string tenso)
    {
        this.CadenaDeTenso = tenso;
    }

    public static Tenso DeCuerda(string tenso)
    {
        tenso = tenso[0].ToString().ToUpper() + tenso[1..].ToLower();
        return tenso switch
        {
            "Presente" => Presente,
            "Futuro" => Futuro,
            "Imperfecto" => Imperfecto,
            "Pretérito" => Pretérito,
            "Condicional" => Condicional,
            "Presente perfecto" => PresentePerfecto,
            "Futuro perfecto" => FuturoPerfecto,
            "Pluscuamperfecto" => Pluscuamperfecto,
            "Pretérito anterior" => PretéritoAnterior,
            "Condicional perfecto" => CondicionalPerfecto,
            _ => throw new ArgumentException("Tenso no reconocido.", nameof(tenso))
        };
    }
}