using Maestro.Biblioteca.Api.Entidad.Autorización;

namespace Maestro.Biblioteca.Api.Servicio.Autorización.ServicioDeTokenDeActualización;

public interface IServicioDeTokenDeActualización
{
    Task<TokenDeActualización> Emitir(int idUsuario, string? huellaDeClaveDpop = null);
    Task<TokenDeActualización?> Rotar(string idDeToken, string? huellaDeClaveDpop = null);
    Task Revocar(string idDeToken);
}
