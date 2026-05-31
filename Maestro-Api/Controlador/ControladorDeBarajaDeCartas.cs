using Microsoft.AspNetCore.Mvc;

namespace Maestro.Controlador;

[ApiController, Route("api/baraja-de-cartas")]
public class ControladorDeBarajaDeCartas : ControllerBase
{
    [HttpPost("agregar")]
    public IActionResult AgregarBarajaDeCartas()
    {
        throw new NotImplementedException("Método no implementado");
    }

    [HttpPost("agregar/tarjeta")]
    public IActionResult AgregarTarjeta()
    {
        throw new NotImplementedException("Método no implementado");
    }
}