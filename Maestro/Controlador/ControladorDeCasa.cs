using Maestro.Excepción;
using Maestro.Modelos.Ia;
using Maestro.Servicio.Conjugación;
using Microsoft.AspNetCore.Mvc;

namespace Maestro.Controlador;

[ApiController]
[Route("api/casa")]
public class ControladorDeCasa : ControllerBase
{
    public ControladorDeCasa()
    {

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

    [HttpGet("ia/palabras")]
    public ActionResult<string> ObtenerPalabras()
    {
        MensajeDeIa mensaje = new MensajeDeIa();
        string respuesta = mensaje.ObtenerListaDePalabras().Result;
        return Ok(respuesta);
    }
}