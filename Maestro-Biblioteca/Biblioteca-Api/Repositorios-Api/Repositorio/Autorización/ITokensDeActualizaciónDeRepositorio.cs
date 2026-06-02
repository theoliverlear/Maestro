using Maestro.Entidad.Autorización;

namespace Maestro.Repositorio.Autorización;

public interface ITokensDeActualizaciónDeRepositorio
{
    TokenDeActualización? ObtenerPorIdDeToken(string idDeToken);
    Task<TokenDeActualización> AgregarAsíncrono(TokenDeActualización token);
    Task GuardarCambiosAsíncronos();
}
