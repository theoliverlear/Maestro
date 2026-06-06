using Maestro.Biblioteca.Api.Comunicación.Respuesta.Palabra.PalabraReal;
using Maestro.Biblioteca.Api.Modelos.Excepción;
using Maestro.Biblioteca.Api.Modelos.Palabra;
using Maestro.Biblioteca.Api.Servicio.Palabra.PalabraReal;
using Microsoft.AspNetCore.Mvc;

namespace Maestro.Api.Controlador;

[ApiController, Route("api/palabra-real")]
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