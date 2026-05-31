using Maestro.Modelos.Verbos;

namespace Maestro.Prueba.Modelos.Verbos;

using Xunit;

public class PruebasDeSufijoVerbal
{
    [Fact]
    public void SufijoVerbal_Constantes_NoEsNulo()
    {
        Assert.NotNull(SufijoVerbal.Ar);
        Assert.NotNull(SufijoVerbal.Er);
        Assert.NotNull(SufijoVerbal.Ir);
    }

    [Fact]
    public void SufijoVerbal_Constantes_SufijosCorrectos()
    {
        Assert.Equal("ar", SufijoVerbal.Ar.Sufijo);
        Assert.Equal("er", SufijoVerbal.Er.Sufijo);
        Assert.Equal("ir", SufijoVerbal.Ir.Sufijo);
    }

    [Fact]
    public void ObtenerSufijo_Er_SufijoCorrecto()
    {
        const string verbo = "comer";
        SufijoVerbal sufijo = SufijoVerbal.ObtenerSufijo(verbo);
        Assert.Equal(SufijoVerbal.Er, sufijo);
    }
}