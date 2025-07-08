using Xunit.Abstractions;

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
}