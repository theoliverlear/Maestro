using Maestro.Biblioteca.Universal.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Maestro.Biblioteca.Universal.Servicios.EntityFramework;

public class ServicioEntityFrameworkDeEntidad<TEntidad, TId, TContexto> :
    ServicioBaseDeEntidad<TEntidad, TId>
    where TEntidad : class, IIdentificable<TId>
    where TId : notnull
    where TContexto : DbContext
{
    private readonly TContexto _contexto;

    public ServicioEntityFrameworkDeEntidad(TContexto contexto,
                                            ILogger<ServicioEntityFrameworkDeEntidad<TEntidad, TId, TContexto>> log)
        : base(log)
    {
        this._contexto = contexto;
    }

    protected TContexto Contexto
    {
        get { return this._contexto; }
    }

    protected DbSet<TEntidad> Entidades
    {
        get { return this._contexto.Set<TEntidad>(); }
    }

    protected override async Task<TEntidad?> EncontrarPorIdEnAlmacenAsync(TId id, CancellationToken ct)
    {
        return await this.Entidades.FindAsync([id], ct);
    }

    protected override async Task<IReadOnlyList<TEntidad>> EncontrarPorIdsEnAlmacenAsync(IReadOnlyCollection<TId> ids,
                                                                                         CancellationToken ct)
    {
        return await this.Entidades
            .Where(entidad => ids.Contains(entidad.Id))
            .ToListAsync(ct);
    }

    protected override async Task<IReadOnlyList<TEntidad>> EncontrarTodosEnAlmacenAsync(CancellationToken ct)
    {
        return await this.Entidades.ToListAsync(ct);
    }

    protected override async Task<bool> ExistePorIdEnAlmacenAsync(TId id, CancellationToken ct)
    {
        return await this.Entidades.AnyAsync(entidad => entidad.Id.Equals(id), ct);
    }

    protected override async Task<long> ContarEnAlmacenAsync(CancellationToken ct)
    {
        return await this.Entidades.LongCountAsync(ct);
    }

    protected override async Task<TEntidad> GuardarEnAlmacenAsync(TEntidad entidad, CancellationToken ct)
    {
        this.Entidades.Update(entidad);
        await this._contexto.SaveChangesAsync(ct);
        return entidad;
    }

    protected override async Task<IReadOnlyList<TEntidad>> GuardarTodosEnAlmacenAsync(IReadOnlyCollection<TEntidad> entidades,
                                                                                      CancellationToken ct)
    {
        this.Entidades.UpdateRange(entidades);
        await this._contexto.SaveChangesAsync(ct);
        return entidades.ToArray();
    }

    protected override async Task<bool> EliminarEnAlmacenAsync(TEntidad entidad, CancellationToken ct)
    {
        this.Entidades.Remove(entidad);
        return await this._contexto.SaveChangesAsync(ct) > 0;
    }

    protected override async Task<bool> EliminarPorIdEnAlmacenAsync(TId id, CancellationToken ct)
    {
        TEntidad? entidad = await this.EncontrarPorIdEnAlmacenAsync(id, ct);
        if (entidad == null)
        {
            return false;
        }

        return await this.EliminarEnAlmacenAsync(entidad, ct);
    }

    protected override async Task<bool> EliminarTodosEnAlmacenAsync(IReadOnlyCollection<TEntidad> entidades,
                                                                    CancellationToken ct)
    {
        this.Entidades.RemoveRange(entidades);
        return await this._contexto.SaveChangesAsync(ct) > 0;
    }
}
