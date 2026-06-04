using Maestro.Biblioteca.Universal.Modelos;

namespace Maestro.Biblioteca.Universal.Servicios;

public interface IConsultaDeEntidad<TEntidad, in TId>
    where TEntidad : IIdentificable<TId>
{
    Task<TEntidad?> EncontrarPorIdAsync(TId id, CancellationToken ct = default);
    Task<IReadOnlyList<TEntidad>> EncontrarPorIdsAsync(IEnumerable<TId> ids, CancellationToken ct = default);
    Task<IReadOnlyList<TEntidad>> EncontrarTodosAsync(CancellationToken ct = default);
    Task<bool> ExisteAsync(TEntidad entidad, CancellationToken ct = default);
    Task<bool> ExistePorIdAsync(TId id, CancellationToken ct = default);
    Task<long> ContarAsync(CancellationToken ct = default);
}
