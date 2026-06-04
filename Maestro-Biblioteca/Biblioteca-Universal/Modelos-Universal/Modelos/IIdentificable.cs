namespace Maestro.Biblioteca.Universal.Modelos;

public interface IIdentificable<TId>
{
    TId Id { get; set; }
}
