using Maestro.Excepción;
using Maestro.Modelos.Ia;
using Maestro.Servicio.Conjugación;
using Microsoft.AspNetCore.Mvc;

namespace Maestro.Controlador;

[ApiController]
[Route("api/casa")]
public class ControladorDeCasa : ControllerBase
{
    private IServicioDeConjugación _servicioDeConjugación;
    public ControladorDeCasa(IServicioDeConjugación servicioDeConjugación)
    {
        this._servicioDeConjugación = servicioDeConjugación;
    }

    private static readonly List<string> Alumnos =
    [
        "Oliver Sigwarth"
    ];

    [HttpGet]
    public ActionResult<IEnumerable<string>> ObtenerTodo() => Ok(Alumnos);

    [HttpGet("alumnos")]
    public ActionResult<List<string>> ObtenerAlumnos()
    {
        return Ok(Alumnos);
    }

    [HttpGet("ai/palabras")]
    public ActionResult<string> ObtenerPalabras()
    {
        MensajeDeIa mensaje = new MensajeDeIa();
        string respuesta = mensaje.ObtenerListaDePalabras().Result;
        return Ok(respuesta);
    }

    [HttpGet("conj/{verbo}/{pronombre}")]
    public ActionResult<string> Conjugar(string verbo, string pronombre)
    {
        string verboConjugado = string.Empty;
        try
        {
            verboConjugado =
                this._servicioDeConjugación.Conjugar(verbo, pronombre);
        }
        catch (ExcepciónDeVerboNoAdmitido ex)
        {
            verboConjugado = ex.Message;
        }

        return Ok(verboConjugado);
    }
}