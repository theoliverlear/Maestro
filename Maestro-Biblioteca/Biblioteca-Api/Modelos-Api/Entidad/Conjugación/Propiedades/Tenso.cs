namespace Maestro.Biblioteca.Api.Entidad.Conjugación.Propiedades;

public class Tenso
{
    public string CadenaDeTenso { get; }

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

        public static readonly List<Tenso> Tensos = new()
        {
            Presente, Futuro, Imperfecto, Pretérito, Condicional, PresentePerfecto,
            FuturoPerfecto, Pluscuamperfecto, PretéritoAnterior, CondicionalPerfecto
        };
    
    public Tenso(string cadenaDeTenso)
    {
        this.CadenaDeTenso = cadenaDeTenso;
    }

    public static Tenso DeCuerda(string cadenaDeTenso)
    {
        foreach (Tenso tenso in Tensos)
        {
            if (string.Equals(
                    tenso.CadenaDeTenso,
                    cadenaDeTenso.Trim(),
                    StringComparison.OrdinalIgnoreCase))
            {
                return tenso;
            }
        }

        throw new ArgumentException("Tenso no reconocido.", nameof(cadenaDeTenso));
    }
}
