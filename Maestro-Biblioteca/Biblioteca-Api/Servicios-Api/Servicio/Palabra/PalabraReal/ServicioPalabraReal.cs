using Maestro.Biblioteca.Api.Modelos.Ia;
using Maestro.Biblioteca.Api.Modelos.Palabra;

namespace Maestro.Biblioteca.Api.Servicio.Palabra.PalabraReal;

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