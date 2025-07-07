using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity;
namespace Maestro.Entidad.Usuario;

[Table("contraseñas_seguros")]
public class ContraseñaSegura : Identificable
{
    [Key, Column("id"), ForeignKey(nameof(Usuario))]
    public int Id { get; set; }

    public Usuario Usuario { get; set; }

    [Column("contraseña_codificada", TypeName = "varchar(100)")]
    public string ContraseñaCodificada { get; set; }

    public ContraseñaSegura()
    {
        this.ContraseñaCodificada = string.Empty;
        this.Usuario = new Usuario();
    }

    public ContraseñaSegura(string contraseñaSinCodificar)
    {
        this.ContraseñaCodificada = this.Codificar(contraseñaSinCodificar);
        this.Usuario = new Usuario();
    }

    public ContraseñaSegura(string contraseñaSinCodificar, Usuario usuario)
    {
        this.ContraseñaCodificada = this.Codificar(contraseñaSinCodificar);
        this.Usuario = usuario;
        this.Id = usuario.Id;
        this.Usuario.IdContraseñaSegura = this.Id;
    }

    public string Codificar(string contraseñaSinCodificar)
    {
        PasswordHasher<ContraseñaSegura> picadora = new PasswordHasher<ContraseñaSegura>();
        return picadora.HashPassword(this, contraseñaSinCodificar);
    }
}