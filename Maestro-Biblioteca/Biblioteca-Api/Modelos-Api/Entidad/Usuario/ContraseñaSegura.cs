using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Maestro.Biblioteca.Universal.Modelos;
using Microsoft.AspNetCore.Identity;

namespace Maestro.Biblioteca.Api.Entidad.Usuario;

[Table("contraseñas_seguros")]
public class ContraseñaSegura : EntidadIdentificable<int>
{
    [NotMapped]
    public Usuario Usuario { get; set; }

    [Column("contraseña_codificada", TypeName = "varchar(100)")]
    public string ContraseñaCodificada { get; set; }

    public ContraseñaSegura()
    {
        this.ContraseñaCodificada = string.Empty;
        this.Usuario = null!;
    }

    public ContraseñaSegura(string contraseñaSinCodificar)
    {
        this.ContraseñaCodificada = this.Codificar(contraseñaSinCodificar);
        this.Usuario = null!;
    }

    public ContraseñaSegura(string contraseñaSinCodificar, Usuario usuario)
    {
        this.ContraseñaCodificada = this.Codificar(contraseñaSinCodificar);
        this.Usuario = usuario;
    }

    public string Codificar(string contraseñaSinCodificar)
    {
        PasswordHasher<ContraseñaSegura> picadora = new();
        return picadora.HashPassword(this, contraseñaSinCodificar);
    }

    public bool CoincidenciasCodificadas(string contraseñaSinCodificar)
    {
        PasswordHasher<ContraseñaSegura> picadora = new();
        PasswordVerificationResult resultado = picadora.VerifyHashedPassword(this, this.ContraseñaCodificada, contraseñaSinCodificar);
        return resultado == PasswordVerificationResult.Success;
    }
}
