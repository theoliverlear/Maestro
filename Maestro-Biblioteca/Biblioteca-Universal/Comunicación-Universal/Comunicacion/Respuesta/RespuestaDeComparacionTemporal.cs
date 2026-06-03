namespace Maestro.Biblioteca.Universal.Comunicacion.Respuesta;

public class RespuestaDeComparacionTemporal : RespuestaDeValorTemporal
{
    public double ValorComparado { get; set; }

    public RespuestaDeComparacionTemporal(string marcaDeTiempo, double valor, double valorComparado)
        : base(marcaDeTiempo, valor)
    {
        this.ValorComparado = valorComparado;
    }
}
