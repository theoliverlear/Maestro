using Maestro.Datos;

namespace Maestro.Repositorio.Usuario;

public class UsuariosDeRepositorio : Repositorio, IUsuariosDeRepositorio
{

    public UsuariosDeRepositorio(ContextoDeBdMaestro bd) : base(bd)
    {

    }
}