namespace Maestro.Biblioteca.Universal.Comunicacion.Respuesta;

public class RespuestaDeValorTemporal
{
    public string MarcaDeTiempo { get; set; }
    public double Valor { get; set; }

    public RespuestaDeValorTemporal()
    {
        this.MarcaDeTiempo = string.Empty;
        this.Valor = 0;
    }

    public RespuestaDeValorTemporal(string marcaDeTiempo, double valor)
    {
        this.MarcaDeTiempo = marcaDeTiempo;
        this.Valor = valor;
    }
}
