using Maestro.Modelos;
using Maestro.Modelos.Verbos;

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

    [Fact]
    public void Conjugado_Tú_Conjugadas()
    {
        Verbo verbo = new Verbo("poder");
        Pronombre pronombre = Pronombre.Tú;
        string resultado = verbo.Conjugado(pronombre);
        Assert.Equal("puedes", resultado);
    }

    [Fact]
    public void Conjugado_Él_Conjugadas()
    {
        Verbo verbo = new Verbo("poder");
        Pronombre pronombre = Pronombre.Él;
        string resultado = verbo.Conjugado(pronombre);
        Assert.Equal("puede", resultado);
    }

    [Fact]
    public void Conjugado_Ella_Conjugadas()
    {
        Verbo verbo = new Verbo("poder");
        Pronombre pronombre = Pronombre.Ella;
        string resultado = verbo.Conjugado(pronombre);
        Assert.Equal("puede", resultado);
    }

    [Fact]
    public void Conjugado_Usted_Conjugadas()
    {
        Verbo verbo = new Verbo("poder");
        Pronombre pronombre = Pronombre.Usted;
        string resultado = verbo.Conjugado(pronombre);
        Assert.Equal("puede", resultado);
    }

    [Fact]
    public void Conjugado_Nosotros_Conjugadas()
    {
        Verbo verbo = new Verbo("poder");
        Pronombre pronombre = Pronombre.Nosotros;
        string resultado = verbo.Conjugado(pronombre);
        Assert.Equal("podemos", resultado);
    }

    [Fact]
    public void Conjugado_Ellos_Conjugadas()
    {
        Verbo verbo = new Verbo("poder");
        Pronombre pronombre = Pronombre.Ellos;
        string resultado = verbo.Conjugado(pronombre);
        Assert.Equal("pueden", resultado);
    }

    [Fact]
    public void Conjugado_Ustedes_Conjugadas()
    {
        Verbo verbo = new Verbo("poder");
        Pronombre pronombre = Pronombre.Ustedes;
        string resultado = verbo.Conjugado(pronombre);
        Assert.Equal("pueden", resultado);
    }
}