namespace Maestro.Api.Entidad.Tarjeta;


public class Tarjeta
{
    private string enEspañol;
    private string enIngles;
    private int dificultad;
    private static readonly string mensajeDeDificultad = "La dificultad debe" +
                                                         " estar entre 1 y 10.";

    public Tarjeta()
    {
        this.enEspañol = string.Empty;
        this.enIngles = string.Empty;
        this.dificultad = -1;
    }

    public Tarjeta(string enEspañol, string enIngles, int dificultad)
    {
        this.enEspañol = enEspañol;
        this.enIngles = enIngles;
        if (dificultad is < 1 or > 10)
        {
            throw new ArgumentOutOfRangeException(nameof(dificultad), mensajeDeDificultad);
        }
        this.dificultad = dificultad;
    }
    public long Id { get; }
    public string EnEspañol { get; set; }

    public string EnIngles { get; set; }

    public int Dificultad
    {
        get => this.dificultad;
        set
        {
            if (value < 1 || value > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(value), mensajeDeDificultad);
            }
            this.dificultad = value;
        }
    }
}