using Microsoft.AspNetCore.Mvc;

namespace Maestro.Api.Controlador;

[ApiController]
[Route("api/[controller]")]
public class ControladorDeCasa : ControllerBase
{
    private static readonly List<string> alumnos =
    [
        "Oliver Sigwarth"
    ];

    [HttpGet]
    public ActionResult<IEnumerable<string>> ObtenerTodo() => Ok(alumnos);

    [HttpGet("alumnos")]
    public ActionResult<List<string>> ObtenerAlumnos()
    {
        return Ok(alumnos);
    }
}