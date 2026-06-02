using Maestro.Datos;
using Maestro.Entidad.Autorización;

namespace Maestro.Repositorio.Autorización;

public class TokensDeActualizaciónDeRepositorio : Repositorio, ITokensDeActualizaciónDeRepositorio
{
    public TokensDeActualizaciónDeRepositorio(ContextoDeBdMaestro bd) : base(bd)
    {
    }

    public TokenDeActualización? ObtenerPorIdDeToken(string idDeToken)
    {
        if (string.IsNullOrWhiteSpace(idDeToken))
        {
            return null;
        }

        return this.Bd.TokensDeActualización.FirstOrDefault(token =>
            token.IdDeToken.Equals(idDeToken));
    }

    public Task<TokenDeActualización> AgregarAsíncrono(TokenDeActualización token)
    {
        return base.AgregarAsíncrono(token).AsTask();
    }
}
