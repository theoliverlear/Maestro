using Maestro.Entidad.Tarjeta;
using Maestro.Entidad.Usuario.Constructor.Modelos;

namespace Maestro.Entidad.Usuario.Constructor;

public class ConstructorDeUsuarios : UsuarioAbstracto
{
    private string _nombre;
    private string _correoElectrónico;
    private ICollection<BarajaDeCartas> _barajasDeCartas;
    private ContraseñaSegura _contraseñaSegura;
    private string _nombreDeUsuario;
    public ConstructorDeUsuarios()
    {
        this._nombre = string.Empty;
        this._correoElectrónico = string.Empty;
        this._barajasDeCartas = new List<BarajaDeCartas>();
        this._contraseñaSegura = new ContraseñaSegura(string.Empty);
        this._nombreDeUsuario = string.Empty;
    }

    public override UsuarioAbstracto ConNombreDeUsuario(string nombreDeUsuario)
    {
        this._nombreDeUsuario = nombreDeUsuario;
        return this;
    }

    public override UsuarioAbstracto ConNombre(string nombre)
    {
        this._nombre = nombre;
        return this;
    }

    public override UsuarioAbstracto ConCorreoElectrónico(string correoElectrónico)
    {
        this._correoElectrónico = correoElectrónico;
        return this;
    }

    public override UsuarioAbstracto ConBarajasDeCartas(ICollection<BarajaDeCartas> barajasDeCartas)
    {
        this._barajasDeCartas = barajasDeCartas;
        return this;
    }

    public override UsuarioAbstracto ConContraseñaSegura(ContraseñaSegura contraseñaSegura)
    {
        this._contraseñaSegura = contraseñaSegura;
        return this;
    }

    public override UsuarioAbstracto ConContraseñaSegura(string contraseñaSegura)
    {
        return this.ConContraseñaSegura(new ContraseñaSegura(contraseñaSegura));
    }

    public override Usuario Construir()
    {
        Usuario usuarioNuevo = new Usuario(
            this._nombre,
            this._correoElectrónico,
            this._barajasDeCartas,
            this._contraseñaSegura,
            this._nombreDeUsuario
        );
        this._contraseñaSegura.Usuario = usuarioNuevo;
        return usuarioNuevo;
    }
}