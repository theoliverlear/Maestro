using Maestro.Biblioteca.Api.Entidad.Usuario;

namespace Maestro.Biblioteca.Api.Servicio.Autorización.ServicioDeTokenJwt;

public interface IServicioDeTokenJwt
{
    string Generar(Usuario usuario, string? huellaDeClaveDpop = null);
}
