namespace Maestro.Prueba.Modelos.Normalizador;
using Maestro.Modelos.Normalizador;

using Xunit;

public class PruebasDeNormalizador
{
    [Fact]
    public void NormalizarCaracteresEspañoles_PalabrasAcentuadas_EliminaLosAcentos()
    {
        const string conAcentos = "áéíóúñüÁÉÍÓÚÑÜ";
        const string sinAcentos = "aeiounuAEIOUNU";
        string resultado = Normalizador.NormalizarCaracteresEspañoles(conAcentos);
        Assert.Equal(sinAcentos, resultado);
    }
}