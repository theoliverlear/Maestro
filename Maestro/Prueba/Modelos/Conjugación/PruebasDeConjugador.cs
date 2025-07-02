using Maestro.Api.Modelos.Conjugación;
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
}