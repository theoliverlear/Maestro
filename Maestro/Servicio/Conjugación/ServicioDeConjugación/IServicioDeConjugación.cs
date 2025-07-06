using Maestro.Modelos;

namespace Maestro.Servicio.Conjugación.ServicioDeConjugación;

public interface IServicioDeConjugación
{
    string Conjugar(string verbo, Pronombre pronombre);
    string Conjugar(string verbo, string pronombre);
}