using Maestro.Biblioteca.Universal.Modelos;

namespace Maestro.Biblioteca.Universal.Servicios;

public interface IPersistenciaDeEntidad<TEntidad, in TId>
    where TEntidad : IIdentificable<TId>
{
    Task<TEntidad> GuardarAsync(TEntidad entidad, CancellationToken ct = default);
    Task<IReadOnlyList<TEntidad>> GuardarTodosAsync(IEnumerable<TEntidad> entidades, CancellationToken ct = default);
    Task<bool> EliminarAsync(TEntidad entidad, CancellationToken ct = default);
    Task<bool> EliminarPorIdAsync(TId id, CancellationToken ct = default);
    Task<bool> EliminarTodosAsync(IEnumerable<TEntidad> entidades, CancellationToken ct = default);
    Task<TEntidad> ActualizarAsync(TEntidad entidad, CancellationToken ct = default);
    Task<IReadOnlyList<TEntidad>> ActualizarTodosAsync(IEnumerable<TEntidad> entidades, CancellationToken ct = default);
}
