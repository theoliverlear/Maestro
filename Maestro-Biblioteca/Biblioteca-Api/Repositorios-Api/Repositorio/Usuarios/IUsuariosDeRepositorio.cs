using Maestro.Entidad.Usuario;

namespace Maestro.Repositorio.Usuarios;

public interface IUsuariosDeRepositorio : IRepositorio
{
    public Usuario? ObtenerPorId(int id);
    public Usuario? ObtenerPorNombreDeUsuario(string nombreDeUsuario);
    public Usuario? ObtenerPorCorreoElectrónico(string correoElectrónico);
}
