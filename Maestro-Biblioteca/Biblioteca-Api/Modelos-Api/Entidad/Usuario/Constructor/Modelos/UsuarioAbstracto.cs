using Maestro.Biblioteca.Api.Entidad.Tarjeta;
using Maestro.Biblioteca.Api.Modelos;

namespace Maestro.Biblioteca.Api.Entidad.Usuario.Constructor.Modelos;

public abstract class UsuarioAbstracto : IFábricaDeConstrucción<Usuario>
{
    public abstract UsuarioAbstracto ConNombre(string nombre);
    public abstract UsuarioAbstracto ConCorreoElectrónico(string correoElectrónico);
    public abstract UsuarioAbstracto ConBarajasDeCartas(ICollection<BarajaDeCartas> barajasDeCartas);
    public abstract UsuarioAbstracto ConContraseñaSegura(ContraseñaSegura contraseñaSegura);
    public abstract UsuarioAbstracto ConContraseñaSegura(string contraseñaSegura);
    public abstract UsuarioAbstracto ConNombreDeUsuario(string nombreDeUsuario);
    public abstract Usuario Construir();
}