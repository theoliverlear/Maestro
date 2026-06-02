using Maestro.Entidad.Usuario;

namespace Maestro.Servicio.Autorización.ServicioDeTokenJwt;

public interface IServicioDeTokenJwt
{
    string Generar(Usuario usuario, string? huellaDeClaveDpop = null);
}
