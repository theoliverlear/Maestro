using Maestro.Api.Entidad.Tarjeta;

namespace Maestro.Api.Entidad.Usuario;

public class Usuario
{
    private long id;
    private string nombre;
    private string correoElectronico;
    private BarajaDeCartas barajaDeCartas;
    public Usuario()
    {
        this.barajaDeCartas = new BarajaDeCartas();
        this.nombre = string.Empty;
        this.correoElectronico = string.Empty;
    }

    public Usuario(string nombre, string correoElectronico)
    {
        this.barajaDeCartas = new BarajaDeCartas();
        this.nombre = nombre;
        this.correoElectronico = correoElectronico;
    }

    public Usuario(string nombre,
                   string correoElectronico,
                   BarajaDeCartas barajaDeCartas)
    {
        this.barajaDeCartas = barajaDeCartas;
        this.nombre = nombre;
        this.correoElectronico = correoElectronico;
    }

    public long Id
    {
        get; set;
    }

    public string Nombre
    {
        get; set;
    }
    public string CorreoElectronico
    {
        get; set;
    }
    public BarajaDeCartas BarajaDeCartas
    {
        get => this.barajaDeCartas;
        set => this.barajaDeCartas = value ?? new BarajaDeCartas();
    }
}