namespace Maestro.Biblioteca.Universal.Modelos;

public abstract class Identificable<TId> : IIdentificable<TId>
{
    public abstract TId Id { get; set; }
}
