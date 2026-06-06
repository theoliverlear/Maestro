using Maestro.Biblioteca.Universal.Repositorio;
using Maestro.Biblioteca.Universal.Componentes.Datos;
using Maestro.Biblioteca.Api.Entidad.Autorización;

namespace Maestro.Biblioteca.Api.Repositorio.Autorización;

public class TokensDeActualizaciónDeRepositorio : Repositorio<ContextoDeBdMaestro>, ITokensDeActualizaciónDeRepositorio
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
