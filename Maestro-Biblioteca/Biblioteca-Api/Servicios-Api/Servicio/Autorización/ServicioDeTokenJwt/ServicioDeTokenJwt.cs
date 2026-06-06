using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Maestro.Biblioteca.Api.Entidad.Usuario;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Maestro.Biblioteca.Api.Servicio.Autorización.ServicioDeTokenJwt;

public class ServicioDeTokenJwt : IServicioDeTokenJwt
{
    private readonly IConfiguration _configuración;

    public ServicioDeTokenJwt(IConfiguration configuración)
    {
        this._configuración = configuración;
    }
    // TODO: Agregar constantes estáticas para cadenas.
    public string Generar(Usuario usuario, string? huellaDeClaveDpop = null)
    {
        string clave = this._configuración["Jwt:Clave"] ??
                       "maestro-clave-de-desarrollo-cambiar-antes-de-producción";
        string emisor = this._configuración["Jwt:Emisor"] ?? "Maestro";
        string audiencia = this._configuración["Jwt:Audiencia"] ?? "Maestro-Sitio-Web";
        int minutos = int.TryParse(this._configuración["Jwt:MinutosDeVida"], out int valor)
            ? valor
            : 15;

        SymmetricSecurityKey claveDeSeguridad = new(Encoding.UTF8.GetBytes(clave));
        SigningCredentials credenciales = new(claveDeSeguridad, SecurityAlgorithms.HmacSha256);
        List<Claim> reclamos =
        [
            new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, usuario.CorreoElectrónico),
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
        ];
        if (!string.IsNullOrWhiteSpace(huellaDeClaveDpop))
        {
            reclamos.Add(new Claim("cnf", $$"""{"jkt":"{{huellaDeClaveDpop}}"}""", JsonClaimValueTypes.Json));
        }

        JwtSecurityToken token = new(
            issuer: emisor,
            audience: audiencia,
            claims: reclamos,
            expires: DateTime.UtcNow.AddMinutes(minutos),
            signingCredentials: credenciales);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
