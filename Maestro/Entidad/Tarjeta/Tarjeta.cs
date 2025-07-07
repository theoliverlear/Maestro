using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maestro.Entidad.Tarjeta;

[Table("tarjetas")]
public class Tarjeta
{
    [Key]
    public int Id { get; set; }

    [Column("en_español", TypeName = "varchar(100)")]
    public string EnEspañol { get; set; }

    [Column("en_inglés", TypeName = "varchar(100)")]
    public string EnInglés { get; set; }

    [Column("dificultad")]
    public int Dificultad
    {
        get => this.Dificultad;
        set
        {
            if (value is < 1 or > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(value), mensajeDeDificultad);
            }
            this.Dificultad = value;
        }
    }
    private static readonly string mensajeDeDificultad = "La dificultad debe" +
                                                         " estar entre 1 y 10.";

    [Column("id_baraja_de_cartas")]
    public int BarajaDeCartasId { get; set; }

    [ForeignKey(nameof(BarajaDeCartasId))]
    public BarajaDeCartas BarajaDeCartas { get; set; }

    public Tarjeta()
    {
        this.EnEspañol = string.Empty;
        this.EnInglés = string.Empty;
        this.Dificultad = 1;
        this.BarajaDeCartasId = 0;
        this.BarajaDeCartas = new BarajaDeCartas();
    }

    public Tarjeta(string enEspañol, string enIngles, int dificultad)
    {
        this.EnEspañol = enEspañol;
        this.EnInglés = enIngles;
        this.Dificultad = dificultad;
        this.BarajaDeCartasId = 0;
        this.BarajaDeCartas = new BarajaDeCartas();
    }
    public Tarjeta(string enEspañol,
                   string enIngles,
                   int dificultad,
                   BarajaDeCartas barajaDeCartas)
    {
        this.EnEspañol = enEspañol;
        this.EnInglés = enIngles;
        this.Dificultad = dificultad;
        this.BarajaDeCartasId = barajaDeCartas.Id;
        this.BarajaDeCartas = barajaDeCartas;
    }
}