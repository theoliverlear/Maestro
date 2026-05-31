using Maestro.Excepción;
using Maestro.Modelos.Conjugación;
using Maestro.Modelos.Conjugación.Diccionario;

namespace Maestro.Prueba.Modelos.Conjugación.Diccionario;

using Xunit;

public class PruebasDeDiccionarioDeConjugación
{

    [Fact]
    public void InicializarDiccionario_Inicializa_NoNulo()
    {
        Assert.NotNull(DiccionarioDeConjugación.Diccionario);
    }

    [Fact]
    public void DetectarVerboNoAdmitidos_VerboInválido_LanzaExcepción()
    {
        string verboInválido = "verboInexistente";
        ExcepciónDeVerboNoAdmitidos excepción = Assert.Throws<ExcepciónDeVerboNoAdmitidos>(() =>
        {
            DiccionarioDeConjugación.DetectarVerboNoAdmitidos(verboInválido);
        });

        string mensajeEsperado = $"Este verbo no está soportado en el" +
                                 $" diccionario de Maestro: {verboInválido}";
        Assert.Equal(mensajeEsperado, excepción.Message);
    }
}