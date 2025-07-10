namespace Maestro.Modelos;

public interface IFábricaDeConstrucción<TModelo>
{
    TModelo Construir();
}