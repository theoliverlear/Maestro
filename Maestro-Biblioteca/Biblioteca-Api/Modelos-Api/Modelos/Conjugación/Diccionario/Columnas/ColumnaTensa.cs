namespace Maestro.Biblioteca.Api.Modelos.Conjugación.Diccionario.Columnas;

public class ColumnaTensa
{
    public string CadenaDeTenso { get; set; }
    public static readonly ColumnaTensa Presente = new("Presente");
    public static readonly ColumnaTensa Futuro = new("Futuro");
    public static readonly ColumnaTensa Imperfecto = new("Imperfecto");
    public static readonly ColumnaTensa Pretérito = new("Pretérito");
    public static readonly ColumnaTensa Condicional = new("Condicional");
    public static readonly ColumnaTensa PresentePerfecto = new("Presente perfecto");
    public static readonly ColumnaTensa FuturoPerfecto = new("Futuro perfecto");
    public static readonly ColumnaTensa Pluscuamperfecto = new("Pluscuamperfecto");
    public static readonly ColumnaTensa PretéritoAnterior = new("Pretérito anterior");
    public static readonly ColumnaTensa CondicionalPerfecto = new("Condicional perfecto");

    public static readonly List<ColumnaTensa> TiemposVerbales = new()
    {
        Presente, Futuro, Imperfecto, Pretérito, Condicional,
        PresentePerfecto, FuturoPerfecto, Pluscuamperfecto, PretéritoAnterior,
        CondicionalPerfecto
    };

    private ColumnaTensa(string tenso)
    {
        this.CadenaDeTenso = tenso;
    }

    public static ColumnaTensa DeCuerda(string tenso)
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