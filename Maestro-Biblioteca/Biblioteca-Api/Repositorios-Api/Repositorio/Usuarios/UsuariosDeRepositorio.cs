using Maestro.Datos;
using Maestro.Entidad.Usuario;

namespace Maestro.Repositorio.Usuarios;

public class UsuariosDeRepositorio : Repositorio, IUsuariosDeRepositorio
{

    public UsuariosDeRepositorio(ContextoDeBdMaestro bd) : base(bd)
    {

    }

    public Usuario? ObtenerPorId(int id)
    {
        return this.Bd.Usuarios.FirstOrDefault(usuarioRepo => usuarioRepo.Id == id);
    }

    public Usuario? ObtenerPorNombreDeUsuario(string nombreDeUsuario)
    {
        if (string.IsNullOrWhiteSpace(nombreDeUsuario))
        {
            return null;
        }

        Usuario? usuario = this.Bd.Usuarios.FirstOrDefault(usuarioRepo =>
            usuarioRepo.NombreDeUsuario.Equals(nombreDeUsuario));
        return usuario;
    }

    public Usuario? ObtenerPorCorreoElectrónico(string correoElectrónico)
    {
        if (string.IsNullOrWhiteSpace(correoElectrónico))
        {
            return null;
        }

        Usuario? usuario = this.Bd.Usuarios.FirstOrDefault(usuarioRepo =>
            usuarioRepo.CorreoElectrónico.Equals(correoElectrónico));
        return usuario;
    }
}
