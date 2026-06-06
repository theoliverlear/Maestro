using Maestro.Biblioteca.Universal.Repositorio;
using Maestro.Biblioteca.Api.Entidad.Autorización;

namespace Maestro.Biblioteca.Api.Repositorio.Autorización;

public interface ITokensDeActualizaciónDeRepositorio
{
    TokenDeActualización? ObtenerPorIdDeToken(string idDeToken);
    Task<TokenDeActualización> AgregarAsíncrono(TokenDeActualización token);
    Task GuardarCambiosAsíncronos();
}
