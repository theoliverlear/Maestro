using Maestro.Biblioteca.Api.Entidad.Autorización;
using Maestro.Biblioteca.Api.Repositorio.Autorización;
using Microsoft.Extensions.Configuration;

namespace Maestro.Biblioteca.Api.Servicio.Autorización.ServicioDeTokenDeActualización;

public class ServicioDeTokenDeActualización : IServicioDeTokenDeActualización
{
    private readonly ITokensDeActualizaciónDeRepositorio _repositorio;
    private readonly IConfiguration _configuración;

    public ServicioDeTokenDeActualización(ITokensDeActualizaciónDeRepositorio repositorio,
                                          IConfiguration configuración)
    {
        this._repositorio = repositorio;
        this._configuración = configuración;
    }

    public Task<TokenDeActualización> Emitir(int idUsuario, string? huellaDeClaveDpop = null)
    {
        TokenDeActualización token = new()
        {
            IdDeToken = Guid.NewGuid().ToString("N"),
            IdDeFamilia = Guid.NewGuid().ToString("N"),
            IdUsuario = idUsuario,
            HuellaDeClaveDpop = huellaDeClaveDpop,
            ExpiraEn = DateTimeOffset.UtcNow.AddDays(this.ObtenerDíasDeVida()),
            Usado = false,
            Revocado = false
        };

        return this._repositorio.AgregarAsíncrono(token);
    }

    public async Task<TokenDeActualización?> Rotar(string idDeToken, string? huellaDeClaveDpop = null)
    {
        TokenDeActualización? token = this._repositorio.ObtenerPorIdDeToken(idDeToken);
        if (token == null ||
            token.Revocado ||
            token.Usado ||
            token.Expirado ||
            token.HuellaDeClaveDpop != huellaDeClaveDpop)
        {
            if (token != null)
            {
                token.Revocado = true;
                await this._repositorio.GuardarCambiosAsíncronos();
            }
            return null;
        }

        token.Usado = true;
        TokenDeActualización tokenNuevo = new()
        {
            IdDeToken = Guid.NewGuid().ToString("N"),
            IdDeFamilia = token.IdDeFamilia,
            IdUsuario = token.IdUsuario,
            HuellaDeClaveDpop = token.HuellaDeClaveDpop,
            ExpiraEn = DateTimeOffset.UtcNow.AddDays(this.ObtenerDíasDeVida()),
            Usado = false,
            Revocado = false
        };

        await this._repositorio.AgregarAsíncrono(tokenNuevo);
        return tokenNuevo;
    }

    public async Task Revocar(string idDeToken)
    {
        TokenDeActualización? token = this._repositorio.ObtenerPorIdDeToken(idDeToken);
        if (token == null)
        {
            return;
        }

        token.Revocado = true;
        await this._repositorio.GuardarCambiosAsíncronos();
    }

    private int ObtenerDíasDeVida()
    {
        return int.TryParse(this._configuración["Jwt:RefreshDíasDeVida"], out int días)
            ? días
            : 30;
    }
}
