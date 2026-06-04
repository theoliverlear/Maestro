namespace Maestro.Biblioteca.Universal.Modelos;

public sealed class EstadoDeAutorizacionUniversal
{
    public string Mensaje { get; }
    public bool EsAutorizado { get; }

    public static readonly EstadoDeAutorizacionUniversal Autorizado = new("Autorizado", true);
    public static readonly EstadoDeAutorizacionUniversal Desautorizado = new("Desautorizado", false);

    public EstadoDeAutorizacionUniversal(string mensaje, bool esAutorizado)
    {
        this.Mensaje = mensaje;
        this.EsAutorizado = esAutorizado;
    }

    public static EstadoDeAutorizacionUniversal Desde(bool esAutorizado)
    {
        return esAutorizado ? Autorizado : Desautorizado;
    }
}
