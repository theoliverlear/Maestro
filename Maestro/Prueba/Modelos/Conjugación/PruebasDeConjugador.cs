using Maestro.Excepción;
using Maestro.Modelos.Conjugación;
using Serilog;
using Xunit.Abstractions;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Maestro.Prueba.Modelos.Conjugación;

using Xunit;

public class PruebasDeConjugador
{
    private readonly ILogger<PruebasDeConjugador> log;

    public PruebasDeConjugador(ITestOutputHelper producción)
    {
        ILoggerFactory fábrica = LoggerFactory.Create(constructora => constructora
                                              .SetMinimumLevel(LogLevel.Debug));
        log = fábrica.AddXunit(producción)
                     .CreateLogger<PruebasDeConjugador>();
    }

    [Fact]
    public void InicializarDiccionario_Inicializa_NoNulo()
    {
        Assert.NotNull(Conjugador.Diccionario);
    }

    [Fact]
    public void DetectarVerboNoAdmitidos_VerboInválido_LanzaExcepción()
    {
        string verboInválido = "verboInexistente";
        ExcepciónDeVerboNoAdmitido excepción = Assert.Throws<ExcepciónDeVerboNoAdmitido>(() =>
        {
            Conjugador.DetectarVerboNoAdmitidos(verboInválido);
        });

        string mensajeEsperado = $"Este verbo no está soportado en el" +
                                 $" diccionario de Maestro: {verboInválido}";
        Assert.Equal(mensajeEsperado, excepción.Message);
    }
}