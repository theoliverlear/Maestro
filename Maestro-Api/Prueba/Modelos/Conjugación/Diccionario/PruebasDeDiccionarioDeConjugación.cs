using Maestro.Biblioteca.Api.Modelos.Excepción;
using Maestro.Biblioteca.Api.Modelos.Conjugación;
using Maestro.Biblioteca.Api.Modelos.Conjugación.Diccionario;

namespace Maestro.Api.Prueba.Modelos.Conjugación.Diccionario;

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