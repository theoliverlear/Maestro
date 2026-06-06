namespace Maestro.Biblioteca.Api.Modelos;

public interface IFábricaDeConstrucción<TModelo>
{
    TModelo Construir();
}