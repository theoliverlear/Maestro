using Maestro.Comunicación.Respuesta.Conjugación;
using Maestro.Excepción;
using Maestro.Servicio.Conjugación.ServicioDeConjugación;
using Microsoft.AspNetCore.Mvc;
namespace Maestro.Controlador;

[ApiController, Route("api/conj")]
public class ControladorDeConjugación : ControllerBase
{
    private readonly IServicioDeConjugación _servicioDeConjugación;

    public ControladorDeConjugación(IServicioDeConjugación servicioDeConjugación)
    {
        this._servicioDeConjugación = servicioDeConjugación;
    }

    [HttpGet("{verbo}/{pronombre}")]
    public ActionResult<RespuestaVerbalConjugada> Conjugar(string verbo,
                                                           string pronombre)
    {
        string verboConjugado;
        try
        {
            verboConjugado = this._servicioDeConjugación.Conjugar(verbo, pronombre);
        }
        catch (Exception)
        {
            verboConjugado = "Verbo no encontrado.";
        }
        return StatusCode(200, new RespuestaVerbalConjugada(verboConjugado));
    }

    [HttpGet("{verbo}/{pronombre}/{ánimo}")]
    public ActionResult<RespuestaVerbalConjugada> Conjugar(string verbo,
                                                           string pronombre,
                                                           string ánimo)
    {
        string verboConjugado;
        try
        {
            verboConjugado = this._servicioDeConjugación.Conjugar(verbo,
                                                                  pronombre,
                                                                  ánimo);
        }
        catch (Exception)
        {
            verboConjugado = "Verbo no encontrado.";
        }
        return StatusCode(200, new RespuestaVerbalConjugada(verboConjugado));
    }

    [HttpGet("{verbo}/{pronombre}/{ánimo}/{tenso}")]
    public ActionResult<RespuestaVerbalConjugada> Conjugar(string verbo,
                                                           string pronombre,
                                                           string ánimo,
                                                           string tenso)
    {
        string verboConjugado;
        try
        {
            verboConjugado = this._servicioDeConjugación.Conjugar(verbo,
                                                                  pronombre,
                                                                  ánimo,
                                                                  tenso);
        }
        catch (Exception)
        {
            verboConjugado = "Verbo no encontrado.";
        }
        return StatusCode(200, new RespuestaVerbalConjugada(verboConjugado));
    }
}