using Maestro.Comunicación.Respuesta.Palabra.PalabraReal;
using Maestro.Excepción;
using Maestro.Modelos.Palabra;
using Maestro.Servicio.Palabra.PalabraReal;
using Microsoft.AspNetCore.Mvc;

namespace Maestro.Controlador;

[ApiController]
[Route("api/palabra-real")]
public class ControladorDePalabraReal : ControllerBase
{
    private readonly IServicioPalabraReal _servicioPalabraReal;
    public ControladorDePalabraReal(IServicioPalabraReal servicioPalabraReal)
    {
        this._servicioPalabraReal = servicioPalabraReal;
    }

    [HttpGet("palabras")]
    public ActionResult<RespuestaDeListaPalabraReal> ObtenerPalabras()
    {
        ListaPalabrasConDificultad? listaPalabras = null;
        try
        {
            listaPalabras = this._servicioPalabraReal.ObtenerPalabras();
        }
        catch (ExcepciónDeSerializaciónFallida ex)
        {
            listaPalabras = new ListaPalabrasConDificultad();
            return StatusCode(500, listaPalabras);
        }
        return StatusCode(200, new RespuestaDeListaPalabraReal(listaPalabras));
    }
}