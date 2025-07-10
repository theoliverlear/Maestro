namespace Maestro.Modelos.Autorización;

public class EstadoDeAutorización
{
    public string Mensaje { get; private set; }
    public bool EsAutorizado { get; private set; }
    public static readonly EstadoDeAutorización Autoizado = new("Autorizado", true);
    public static readonly EstadoDeAutorización Desautorizado = new("Desautorizado", false);
    public static readonly EstadoDeAutorización NoAutorizado = new("No autorizado", false);

    public EstadoDeAutorización(string mensaje, bool esAutorizado)
    {
        this.Mensaje = mensaje;
        this.EsAutorizado = esAutorizado;
    }
}