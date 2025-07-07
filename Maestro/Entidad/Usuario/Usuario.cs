using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Maestro.Entidad.Tarjeta;

namespace Maestro.Entidad.Usuario;

[Table("usuarios")]
public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Column("nombre", TypeName = "varchar(100)")]
    public string Nombre { get; set; }

    [Column("correo_electrónico", TypeName = "varchar(100)")]
    public string CorreoElectrónico { get; set; }

    [Column("id_baraja_de_cartas")]
    public int IdBarajaDeCartas { get; set; }

    [ForeignKey(nameof(IdBarajaDeCartas))]
    public BarajaDeCartas BarajaDeCartas { get; set; }

    public Usuario() : this(string.Empty, string.Empty)
    {

    }

    public Usuario(string nombre, string correoElectrónico) : this(nombre, correoElectrónico, new BarajaDeCartas())
    {

    }

    public Usuario(string nombre,
                   string correoElectrónico,
                   BarajaDeCartas barajaDeCartas)
    {
        this.BarajaDeCartas = barajaDeCartas;
        this.Nombre = nombre;
        this.CorreoElectrónico = correoElectrónico;
        this.IdBarajaDeCartas = barajaDeCartas.Id;
    }
}