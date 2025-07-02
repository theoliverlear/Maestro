using Maestro.Api.Modelos;
using Maestro.Api.Modelos.Verbos;

namespace Maestro.Prueba.Modelos.Verbos;
using Xunit;


public class PruebasDeVerbos
{
    [Fact]
    public void Conjugado_Yo_Conjugadas()
    {
        Verbo verbo = new Verbo("poder");
        Pronombre pronombre = Pronombre.Yo;
        string resultado = verbo.Conjugado(pronombre);
        Assert.Equal("puedo", resultado);
    }
}