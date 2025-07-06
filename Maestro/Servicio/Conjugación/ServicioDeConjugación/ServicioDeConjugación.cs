using Maestro.Modelos;
using Maestro.Modelos.Conjugación;
using Maestro.Servicio.Conjugación;

namespace Maestro.Servicio.Conjugación.ServicioDeConjugación;

public class ServicioDeConjugación : IServicioDeConjugación
{
    public string Conjugar(string verbo, string pronombre)
    {
        return this.Conjugar(verbo, Pronombre.DeCuerda(pronombre));
    }

    public string Conjugar(string verbo, Pronombre pronombre)
    {
        return Conjugador.ObtenerPorPronombre(verbo, pronombre);
    }
}
