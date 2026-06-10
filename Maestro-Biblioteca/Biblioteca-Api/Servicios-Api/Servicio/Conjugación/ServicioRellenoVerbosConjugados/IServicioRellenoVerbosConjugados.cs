namespace Maestro.Biblioteca.Api.Servicio.Conjugación.ServicioRellenoVerbosConjugados;

public interface IServicioRellenoVerbosConjugados
{
    Task RellenarSiConfiguradoAsync(CancellationToken cancellationToken = default);
}
