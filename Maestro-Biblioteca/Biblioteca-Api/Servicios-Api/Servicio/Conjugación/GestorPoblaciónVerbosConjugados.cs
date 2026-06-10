using Maestro.Biblioteca.Api.Servicio.Conjugación.ServicioRellenoVerbosConjugados;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Maestro.Biblioteca.Api.Servicio.Conjugación;

public sealed class GestorPoblaciónVerbosConjugados : BackgroundService
{
    private readonly IServiceScopeFactory fábricaDeScopes;
    private readonly ILogger<GestorPoblaciónVerbosConjugados> log;

    public GestorPoblaciónVerbosConjugados(
        IServiceScopeFactory fábricaDeScopes,
        ILogger<GestorPoblaciónVerbosConjugados> log)
    {
        this.fábricaDeScopes = fábricaDeScopes;
        this.log = log;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using IServiceScope scope = this.fábricaDeScopes.CreateScope();

        IServicioRellenoVerbosConjugados servicio = scope.ServiceProvider
            .GetRequiredService<IServicioRellenoVerbosConjugados>();

        await servicio.RellenarSiConfiguradoAsync(stoppingToken);
        this.log.LogInformation("Revisión de relleno de verbos conjugados completada.");
    }
}
