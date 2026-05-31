using Maestro.Modelos.Ia;
using Maestro.Modelos.Palabra;

namespace Maestro.Servicio.Palabra.PalabraReal;

public class ServicioPalabraReal : IServicioPalabraReal
{
    private ClienteDePalabraReal cliente;

    public ServicioPalabraReal()
    {
        this.cliente = new ClienteDePalabraReal();
    }
    public ListaPalabrasConDificultad ObtenerPalabras()
    {
        return this.cliente.ObtenerPalabras();
    }
}