using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Maestro.Biblioteca.Universal.Modelos;
using Maestro.Biblioteca.Api.Entidad.Tarjeta;
using Maestro.Biblioteca.Api.Entidad.Usuario.Constructor;

namespace Maestro.Biblioteca.Api.Entidad.Usuario;

[Table("usuarios")]
public class Usuario : EntidadIdentificable<int>
{
    [Column("nombre", TypeName = "varchar(100)")]
    public string Nombre { get; set; }

    [Column("nombre_de_usuario", TypeName = "varchar(100)")]
    public string NombreDeUsuario { get; set; }

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
        this.NombreDeUsuario = string.Empty;
    }

    public Usuario(string nombre,
                   string correoElectrónico,
                   ICollection<BarajaDeCartas> barajasDeCartas,
                   ContraseñaSegura contraseñaSegura,
                   string nombreDeUsuario) : this(nombre, correoElectrónico,
                   barajasDeCartas, contraseñaSegura)
    {
        this.NombreDeUsuario = nombreDeUsuario;
    }

    public static ConstructorDeUsuarios Constructor()
    {
        return new ConstructorDeUsuarios();
    }
}
