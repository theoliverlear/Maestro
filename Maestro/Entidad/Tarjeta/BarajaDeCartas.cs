using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maestro.Entidad.Tarjeta;

using Maestro.Entidad.Usuario;

[Table("barajas_de_cartas")]
public class BarajaDeCartas : Identificable
{
    [Key, Column("id"), ForeignKey(nameof(Usuario))]
    public int Id { get; set; }

    [InverseProperty(nameof(BarajaDeCartas))]
    public ICollection<Tarjeta> Cartas { get; set; }

    public Usuario Usuario { get; set; }

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
    }
}