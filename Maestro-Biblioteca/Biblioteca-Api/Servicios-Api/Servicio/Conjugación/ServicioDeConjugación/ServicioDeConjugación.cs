using Maestro.Modelos;
using Maestro.Modelos.Conjugación;

namespace Maestro.Servicio.Conjugación.ServicioDeConjugación;

public class ServicioDeConjugación : IServicioDeConjugación
{
    public string Conjugar(string verbo, string pronombre)
    {
        return this.Conjugar(verbo, Pronombre.DeCuerda(pronombre));
    }

    public string Conjugar(string verbo, Pronombre pronombre)
    {
        return Conjugador.ConjugarConVerboPronombre(verbo, pronombre);
    }

    public string Conjugar(string verbo, string pronombre, string ánimo)
    {
        return Conjugador.ConjugarConVerboPronombreÁnimo(verbo, pronombre, ánimo);
    }

    public string Conjugar(string verbo, string pronombre, string ánimo, string tenso)
    {
        return Conjugador.Conjugado(verbo, ánimo, tenso, pronombre);
    }
}
