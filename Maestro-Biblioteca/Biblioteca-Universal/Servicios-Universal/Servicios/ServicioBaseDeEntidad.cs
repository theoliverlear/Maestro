using Maestro.Biblioteca.Universal.Modelos;
using Maestro.Biblioteca.Universal.Modelos.Excepciones;
using Microsoft.Extensions.Logging;

namespace Maestro.Biblioteca.Universal.Servicios;

public abstract class ServicioBaseDeEntidad<TEntidad, TId> : IGestorDeEntidad<TEntidad, TId>
    where TEntidad : IIdentificable<TId>
    where TId : notnull
{
    private readonly ILogger _log;

    protected ServicioBaseDeEntidad(ILogger log)
    {
        this._log = log;
    }

    protected ILogger Log
    {
        get { return this._log; }
    }

    public async Task<TEntidad> GuardarSiNuevaAsync(TEntidad entidad, CancellationToken ct = default)
    {
        if (!await this.ExisteAsync(entidad, ct))
        {
            return await this.GuardarAsync(entidad, ct);
        }

        this._log.LogInformation(
            "{TipoEntidad} ya existe; se omite el guardado. {Contenido}",
            this.ObtenerNombreDeEntidad(entidad),
            RegistradorDeEntidad.ObtenerContenidoRegistrable(entidad));
        return entidad;
    }

    public async Task<bool> EliminarSiExisteAsync(TEntidad entidad, CancellationToken ct = default)
    {
        if (await this.ExisteAsync(entidad, ct))
        {
            return await this.EliminarAsync(entidad, ct);
        }

        this._log.LogWarning(
            "{TipoEntidad} no existe; no se puede eliminar. {Contenido}",
            this.ObtenerNombreDeEntidad(entidad),
            RegistradorDeEntidad.ObtenerContenidoRegistrable(entidad));
        return false;
    }

    public async Task<TEntidad?> EncontrarPorIdAsync(TId id, CancellationToken ct = default)
    {
        this._log.LogInformation("Buscando {TipoEntidad} con ID {Id}.", this.ObtenerNombreDeEntidad(), id);
        return await this.EncontrarPorIdEnAlmacenAsync(id, ct);
    }

    public async Task<IReadOnlyList<TEntidad>> EncontrarPorIdsAsync(IEnumerable<TId> ids, CancellationToken ct = default)
    {
        TId[] idsMaterializados = ids.ToArray();
        this._log.LogInformation("Buscando {Cantidad} {TipoEntidad}.", idsMaterializados.Length, this.ObtenerNombreDeEntidad());
        return await this.EncontrarPorIdsEnAlmacenAsync(idsMaterializados, ct);
    }

    public async Task<IReadOnlyList<TEntidad>> EncontrarTodosAsync(CancellationToken ct = default)
    {
        IReadOnlyList<TEntidad> entidades = await this.EncontrarTodosEnAlmacenAsync(ct);
        this._log.LogInformation(
            "Encontradas {Cantidad} entidades {TipoEntidad}.",
            entidades.Count,
            this.ObtenerNombreDeEntidad());
        return entidades;
    }

    public async Task<bool> ExisteAsync(TEntidad entidad, CancellationToken ct = default)
    {
        this._log.LogInformation(
            "Comprobando existencia de {TipoEntidad}. {Contenido}",
            this.ObtenerNombreDeEntidad(entidad),
            RegistradorDeEntidad.ObtenerContenidoRegistrable(entidad));
        return await this.ExistePorIdAsync(entidad.Id, ct);
    }

    public async Task<bool> ExistePorIdAsync(TId id, CancellationToken ct = default)
    {
        this._log.LogInformation("Comprobando existencia de {TipoEntidad} con ID {Id}.", this.ObtenerNombreDeEntidad(), id);
        return await this.ExistePorIdEnAlmacenAsync(id, ct);
    }

    public async Task<long> ContarAsync(CancellationToken ct = default)
    {
        this._log.LogInformation("Contando entidades {TipoEntidad}.", this.ObtenerNombreDeEntidad());
        return await this.ContarEnAlmacenAsync(ct);
    }

    public async Task<TEntidad> GuardarAsync(TEntidad entidad, CancellationToken ct = default)
    {
        this._log.LogInformation(
            "Guardando {TipoEntidad}. {Contenido}",
            this.ObtenerNombreDeEntidad(entidad),
            RegistradorDeEntidad.ObtenerContenidoRegistrable(entidad));
        return await this.GuardarEnAlmacenAsync(entidad, ct);
    }

    public async Task<IReadOnlyList<TEntidad>> GuardarTodosAsync(IEnumerable<TEntidad> entidades, CancellationToken ct = default)
    {
        TEntidad[] entidadesMaterializadas = entidades.ToArray();
        this._log.LogInformation(
            "Guardando {Cantidad} entidades {TipoEntidad}.",
            entidadesMaterializadas.Length,
            this.ObtenerNombreDeEntidad());
        return await this.GuardarTodosEnAlmacenAsync(entidadesMaterializadas, ct);
    }

    public async Task<bool> EliminarAsync(TEntidad entidad, CancellationToken ct = default)
    {
        this._log.LogInformation(
            "Eliminando {TipoEntidad}. {Contenido}",
            this.ObtenerNombreDeEntidad(entidad),
            RegistradorDeEntidad.ObtenerContenidoRegistrable(entidad));
        return await this.EliminarEnAlmacenAsync(entidad, ct);
    }

    public async Task<bool> EliminarPorIdAsync(TId id, CancellationToken ct = default)
    {
        if (!await this.ExistePorIdAsync(id, ct))
        {
            this._log.LogWarning("Entidad con ID {Id} no existe; no se puede eliminar.", id);
            return false;
        }

        this._log.LogInformation("Eliminando {TipoEntidad} con ID {Id}.", this.ObtenerNombreDeEntidad(), id);
        return await this.EliminarPorIdEnAlmacenAsync(id, ct);
    }

    public async Task<bool> EliminarTodosAsync(IEnumerable<TEntidad> entidades, CancellationToken ct = default)
    {
        TEntidad[] entidadesMaterializadas = entidades.ToArray();
        foreach (TEntidad entidad in entidadesMaterializadas)
        {
            if (!await this.ExisteAsync(entidad, ct))
            {
                this._log.LogError(
                    "No se pudieron eliminar {Cantidad} entidades {TipoEntidad}; no todas existen.",
                    entidadesMaterializadas.Length,
                    this.ObtenerNombreDeEntidad());
                return false;
            }
        }

        this._log.LogInformation(
            "Eliminando {Cantidad} entidades {TipoEntidad}.",
            entidadesMaterializadas.Length,
            this.ObtenerNombreDeEntidad());
        return await this.EliminarTodosEnAlmacenAsync(entidadesMaterializadas, ct);
    }

    public async Task<TEntidad> ActualizarAsync(TEntidad entidad, CancellationToken ct = default)
    {
        if (await this.ExisteAsync(entidad, ct))
        {
            this._log.LogInformation(
                "Actualizando {TipoEntidad}. {Contenido}",
                this.ObtenerNombreDeEntidad(entidad),
                RegistradorDeEntidad.ObtenerContenidoRegistrable(entidad));
            return await this.GuardarAsync(entidad, ct);
        }

        this._log.LogError(
            "No se pudo actualizar {TipoEntidad}; no existe. {Contenido}",
            this.ObtenerNombreDeEntidad(entidad),
            RegistradorDeEntidad.ObtenerContenidoRegistrable(entidad));
        throw ExcepcionDeEntidadNoEncontrada.Desde(entidad);
    }

    public async Task<IReadOnlyList<TEntidad>> ActualizarTodosAsync(IEnumerable<TEntidad> entidades, CancellationToken ct = default)
    {
        TEntidad[] entidadesMaterializadas = entidades.ToArray();
        foreach (TEntidad entidad in entidadesMaterializadas)
        {
            if (!await this.ExisteAsync(entidad, ct))
            {
                this._log.LogError(
                    "No se pudieron actualizar {Cantidad} entidades {TipoEntidad}; no todas existen.",
                    entidadesMaterializadas.Length,
                    this.ObtenerNombreDeEntidad());
                throw new ExcepcionDeEntidadNoEncontrada();
            }
        }

        return await this.GuardarTodosAsync(entidadesMaterializadas, ct);
    }

    protected virtual string ObtenerNombreDeEntidad(TEntidad? entidad = default)
    {
        return (entidad?.GetType() ?? typeof(TEntidad)).Name;
    }

    protected abstract Task<TEntidad?> EncontrarPorIdEnAlmacenAsync(TId id, CancellationToken ct);
    protected abstract Task<IReadOnlyList<TEntidad>> EncontrarPorIdsEnAlmacenAsync(IReadOnlyCollection<TId> ids, CancellationToken ct);
    protected abstract Task<IReadOnlyList<TEntidad>> EncontrarTodosEnAlmacenAsync(CancellationToken ct);
    protected abstract Task<bool> ExistePorIdEnAlmacenAsync(TId id, CancellationToken ct);
    protected abstract Task<long> ContarEnAlmacenAsync(CancellationToken ct);
    protected abstract Task<TEntidad> GuardarEnAlmacenAsync(TEntidad entidad, CancellationToken ct);
    protected abstract Task<IReadOnlyList<TEntidad>> GuardarTodosEnAlmacenAsync(IReadOnlyCollection<TEntidad> entidades, CancellationToken ct);
    protected abstract Task<bool> EliminarEnAlmacenAsync(TEntidad entidad, CancellationToken ct);
    protected abstract Task<bool> EliminarPorIdEnAlmacenAsync(TId id, CancellationToken ct);
    protected abstract Task<bool> EliminarTodosEnAlmacenAsync(IReadOnlyCollection<TEntidad> entidades, CancellationToken ct);
}
