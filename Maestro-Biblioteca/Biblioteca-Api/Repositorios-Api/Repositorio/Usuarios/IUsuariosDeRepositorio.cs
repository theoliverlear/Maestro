using Maestro.Biblioteca.Universal.Repositorio;
using Maestro.Biblioteca.Api.Entidad.Usuario;

namespace Maestro.Biblioteca.Api.Repositorio.Usuarios;

public interface IUsuariosDeRepositorio : IRepositorio
{
    public Usuario? ObtenerPorId(int id);
    public Usuario? ObtenerPorNombreDeUsuario(string nombreDeUsuario);
    public Usuario? ObtenerPorCorreoElectrónico(string correoElectrónico);
}
