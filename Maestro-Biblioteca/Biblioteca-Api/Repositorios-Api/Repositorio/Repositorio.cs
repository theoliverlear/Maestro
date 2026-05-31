using Maestro.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Maestro.Repositorio;

public class Repositorio : IRepositorio
{
    private readonly ContextoDeBdMaestro _bd;

    public Repositorio(ContextoDeBdMaestro bd)
    {
        this._bd = bd;
    }

    protected ContextoDeBdMaestro Bd
    {
        get { return this._bd; }
    }

    public Task GuardarCambiosAsíncronos()
    {
        return this._bd.SaveChangesAsync();
    }

    public ValueTask<TEntidad?> ObtenerPorIdAsíncrono<TEntidad>(int id) where TEntidad : class
    {
        return this._bd.ObtenerConjuntoPorEntidad<TEntidad>()
                       .FindAsync(id);
    }

    public async ValueTask<TEntidad> AgregarAsíncrono<TEntidad>(TEntidad entidad) where TEntidad : class
    {
        EntityEntry<TEntidad> nuevaEntidad = this._bd.ObtenerConjuntoPorEntidad<TEntidad>().Add(entidad);
        await this.GuardarCambiosAsíncronos();
        entidad = nuevaEntidad.Entity;
        return entidad;
    }

    public async Task ActualizarAsíncrono<TEntidad>(TEntidad entidad) where TEntidad : class
    {
        this._bd.Attach(entidad);
        this._bd.Entry(entidad).State = EntityState.Modified;
        await this.GuardarCambiosAsíncronos();
    }

    public async Task EliminarAsíncrono<TEntidad>(int id) where TEntidad : class
    {
        TEntidad? entidad = await this.ObtenerPorIdAsíncrono<TEntidad>(id);
        if (entidad != null)
        {
            this._bd.ObtenerConjuntoPorEntidad<TEntidad>().Remove(entidad);
            await this.GuardarCambiosAsíncronos();
        }
        else
        {
            throw new KeyNotFoundException($"No se encontró la entidad con ID {id}.");
        }
    }

    public async Task EliminarAsíncrono<TEntidad>(TEntidad entidad) where TEntidad : class
    {
        this._bd.ObtenerConjuntoPorEntidad<TEntidad>().Remove(entidad);
        await this.GuardarCambiosAsíncronos();
    }

    public async Task<bool> ExistePorId<TEntidad>(int id)
    {
        object? entidad = await this._bd.ObtenerConjuntoPorEntidad<object>().FindAsync(id);
        return entidad != null;
    }
}