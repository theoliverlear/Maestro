using Maestro.Biblioteca.Universal.Modelos;

namespace Maestro.Biblioteca.Universal.Servicios;

public interface IGestorDeEntidad<TEntidad, TId> :
    IConsultaDeEntidad<TEntidad, TId>,
    IPersistenciaDeEntidad<TEntidad, TId>
    where TEntidad : IIdentificable<TId>
{
    Task<TEntidad> GuardarSiNuevaAsync(TEntidad entidad, CancellationToken ct = default);
    Task<bool> EliminarSiExisteAsync(TEntidad entidad, CancellationToken ct = default);
}
