using Maestro.Entidad.Usuario;

namespace Maestro.Repositorio.Usuarios;

public interface IUsuariosDeRepositorio : IRepositorio
{
    public Usuario? ObtenerPorNombreDeUsuario(string nombreDeUsuario);
}