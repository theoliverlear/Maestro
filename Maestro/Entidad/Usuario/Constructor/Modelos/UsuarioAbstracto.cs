using Maestro.Entidad.Tarjeta;
using Maestro.Modelos;

namespace Maestro.Entidad.Usuario.Constructor.Modelos;

public abstract class UsuarioAbstracto : IFábricaDeConstrucción<Usuario>
{
    public abstract UsuarioAbstracto ConNombre(string nombre);
    public abstract UsuarioAbstracto ConCorreoElectrónico(string correoElectrónico);
    public abstract UsuarioAbstracto ConBarajasDeCartas(ICollection<BarajaDeCartas> barajasDeCartas);
    public abstract UsuarioAbstracto ConContraseñaSegura(ContraseñaSegura contraseñaSegura);
    public abstract Usuario Construir();
}