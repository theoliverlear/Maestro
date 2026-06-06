using Maestro.Biblioteca.Api.Modelos.Ia;
using Maestro.Biblioteca.Api.Modelos.Palabra;
using Microsoft.Extensions.Configuration;

namespace Maestro.Biblioteca.Api.Servicio.Palabra.PalabraReal;

public class ServicioPalabraReal : IServicioPalabraReal
{
    private ClienteDePalabraReal cliente;

    public ServicioPalabraReal(IConfiguration configuración)
    {
        this.cliente = new ClienteDePalabraReal(configuración);
    }
    public ListaPalabrasConDificultad ObtenerPalabras()
    {
        return this.cliente.ObtenerPalabras();
    }
}
