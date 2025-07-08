using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Maestro.Entidad.Tarjeta;

namespace Maestro.Entidad.Usuario;

[Table("usuarios")]
public class Usuario : Identificable
{
    [Column("nombre", TypeName = "varchar(100)")]
    public string Nombre { get; set; }

    [Column("correo_electrónico", TypeName = "varchar(100)")]
    public string CorreoElectrónico { get; set; }

    public ICollection<BarajaDeCartas> BarajasDeCartas { get; set; } = new List<BarajaDeCartas>();

    [Column("id_contraseña_segura")]
    public int IdContraseñaSegura { get; set; }

    [ForeignKey(nameof(IdContraseñaSegura))]
    public ContraseñaSegura ContraseñaSegura { get; set; }

    public Usuario() : this(string.Empty, string.Empty)
    {

    }

    public Usuario(string nombre, string correoElectrónico) : this(nombre, correoElectrónico, new List<BarajaDeCartas>())
    {

    }

    public Usuario(string nombre,
                   string correoElectrónico,
                   ICollection<BarajaDeCartas> barajasDeCartas)
    {
        this.BarajasDeCartas = barajasDeCartas;
        this.Nombre = nombre;
        this.CorreoElectrónico = correoElectrónico;
        this.ContraseñaSegura = new ContraseñaSegura(string.Empty, this);
        this.IdContraseñaSegura = this.ContraseñaSegura.Id;
    }

    public Usuario(string nombre,
                   string correoElectrónico,
                   ICollection<BarajaDeCartas> barajasDeCartas,
                   ContraseñaSegura contraseñaSegura)
    {
        this.BarajasDeCartas = barajasDeCartas;
        this.Nombre = nombre;
        this.CorreoElectrónico = correoElectrónico;
        this.ContraseñaSegura = contraseñaSegura;
        this.IdContraseñaSegura = contraseñaSegura.Id;
    }
}

