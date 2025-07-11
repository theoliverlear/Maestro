using Maestro.Datos;
using Maestro.Entidad.Usuario;

namespace Maestro.Repositorio.Usuarios;

public class UsuariosDeRepositorio : Repositorio, IUsuariosDeRepositorio
{

    public UsuariosDeRepositorio(ContextoDeBdMaestro bd) : base(bd)
    {

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
}