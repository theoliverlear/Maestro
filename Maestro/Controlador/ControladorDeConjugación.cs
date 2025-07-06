using Maestro.Comunicación.Respuesta.Conjugación;
using Maestro.Excepción;
using Maestro.Servicio.Conjugación.ServicioDeConjugación;
using Microsoft.AspNetCore.Mvc;
namespace Maestro.Controlador;

[ApiController]
[Route("api/conj")]
public class ControladorDeConjugación : ControllerBase
{
    private IServicioDeConjugación _servicioDeConjugación;

    public ControladorDeConjugación(
        IServicioDeConjugación servicioDeConjugación)
    {
        this._servicioDeConjugación = servicioDeConjugación;
    }

    [HttpGet("{verbo}/{pronombre}")]
    public ActionResult<RespuestaVerbalConjugada> Conjugar(string verbo, string pronombre)
    {
        string verboConjugado = string.Empty;
        try
        {
            verboConjugado =
                this._servicioDeConjugación.Conjugar(verbo, pronombre);
        }
        catch (ExcepciónDeVerboNoAdmitido ex)
        {
            verboConjugado = "Verbo no encontrado.";
        }
        return StatusCode(200, new RespuestaVerbalConjugada(verboConjugado));
    }
}