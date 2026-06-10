using Maestro.Biblioteca.Api.Entidad.Conjugación;
using Maestro.Biblioteca.Api.Modelos.Conjugación.Diccionario;
using Maestro.Biblioteca.Universal.Modelos;

namespace Maestro.Biblioteca.Api.Servicio.Conjugación.ServicioTransformadorConjugadorRellenador;

public interface IServicioTransformadorConjugadorRellenador
    : ITransformadorModelo<FilaDeConjugación, VerboConjugado>
{
}
