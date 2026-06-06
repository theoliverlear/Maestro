using Maestro.Biblioteca.Api.Modelos;

namespace Maestro.Biblioteca.Api.Servicio.Conjugación.ServicioDeConjugación;

public interface IServicioDeConjugación
{
    string Conjugar(string verbo, Pronombre pronombre);
    string Conjugar(string verbo, string pronombre);
    string Conjugar(string verbo, string pronombre, string ánimo);
    string Conjugar(string verbo, string pronombre, string ánimo, string tenso);
}