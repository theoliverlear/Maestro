namespace Maestro.Biblioteca.Universal.Modelos;

public interface IFabricaDeConstruccion<out TModelo>
{
    TModelo Construir();
}
