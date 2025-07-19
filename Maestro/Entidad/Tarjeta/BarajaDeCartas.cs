using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maestro.Entidad.Tarjeta;

using Maestro.Entidad.Usuario;

[Table("barajas_de_cartas")]
public class BarajaDeCartas : Identificable
{
    [InverseProperty(nameof(BarajaDeCartas))]
    public ICollection<Tarjeta> Cartas { get; set; }

    [Column("título", TypeName = "varchar(100)")]
    public string Título { get; set; }

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [ForeignKey(nameof(IdUsuario))]
    public Usuario Usuario { get; set; }

    public BarajaDeCartas(string título) : this(new Usuario(), new List<Tarjeta>(), título)
    {
        this.Título = título;
    }

    public BarajaDeCartas() : this(new List<Tarjeta>())
    {

    }

    public BarajaDeCartas(List<Tarjeta> cartas) : this(new Usuario(), cartas)
    {

    }

    public BarajaDeCartas(Usuario usuario, List<Tarjeta> cartas)
    {
        this.Usuario = usuario;
        this.Cartas = cartas;
        this.Título = string.Empty;
    }

    public BarajaDeCartas(Usuario usuario, ICollection<Tarjeta> cartas, string título)
    {
        this.Usuario = usuario;
        this.Cartas = cartas;
        this.Título = título;
    }
}