using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity;
namespace Maestro.Entidad.Usuario;

public class ContraseñaSegura
{
    private long id;
    private string contraseñaCodificada;

    public ContraseñaSegura(string contraseñaSinCodificar)
    {
        this.contraseñaCodificada = this.Codificar(contraseñaSinCodificar);
    }

    public string Codificar(string contraseñaSinCodificar)
    {
        PasswordHasher<ContraseñaSegura> picadora = new PasswordHasher<ContraseñaSegura>();
        return picadora.HashPassword(this, contraseñaSinCodificar);
    }

    public string ContraseñaCodificada
    {
        get; set;
    }
}