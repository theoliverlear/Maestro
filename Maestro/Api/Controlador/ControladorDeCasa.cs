using Maestro.Api.Modelos.Ai;
using Microsoft.AspNetCore.Mvc;

namespace Maestro.Api.Controlador;

[ApiController]
[Route("api/casa")]
public class ControladorDeCasa : ControllerBase
{
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
        MensajeDeAi mensaje = new MensajeDeAi();
        string respuesta = mensaje.ObtenerListaDePalabras().Result;
        return Ok(respuesta);
    }
}