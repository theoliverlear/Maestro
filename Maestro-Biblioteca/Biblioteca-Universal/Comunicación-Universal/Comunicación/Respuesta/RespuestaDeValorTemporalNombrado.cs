namespace Maestro.Biblioteca.Universal.Comunicación.Respuesta;

public class RespuestaDeValorTemporalNombrado : RespuestaDeValorTemporal
{
    public string Nombre { get; set; }

    public RespuestaDeValorTemporalNombrado()
    {
        this.Nombre = string.Empty;
    }

    public RespuestaDeValorTemporalNombrado(string nombre, string marcaDeTiempo, double valor)
        : base(marcaDeTiempo, valor)
    {
        this.Nombre = nombre;
    }
}
