using Maestro.Biblioteca.Api.Entidad.Conjugación;
using Maestro.Biblioteca.Api.Entidad.Conjugación.Propiedades;
using Maestro.Biblioteca.Api.Modelos.Conjugación.Diccionario;
using Maestro.Biblioteca.Universal.Modelos;

namespace Maestro.Biblioteca.Api.Servicio.Conjugación.ServicioTransformadorConjugadorRellenador;

public class ServicioTransformadorConjugadorRellenador
    : ModeloTransformado<FilaDeConjugación, VerboConjugado>,
      IServicioTransformadorConjugadorRellenador
{
    public override VerboConjugado Transformar(FilaDeConjugación original)
    {
        ArgumentNullException.ThrowIfNull(original);

        return new VerboConjugado
        {
            Infinitivo = original.Infinitivo,
            InfinitivoInglés = original.InfinitivoEnInglés,
            Ánimo = Ánimo.DeCuerda(original.Ánimo),
            ÁnimoInglés = ÁnimoInglés.DeCuerda(original.ÁnimoEnInglés),
            Tenso = Tenso.DeCuerda(original.Tenso),
            TensoInglés = TensoInglés.DeCuerda(original.TensoEnInglés),
            VerboInglés = original.VerboInglés,
            PrimeraPersonaSingular = NormalizarForma(original.Yo),
            SegundaPersonaSingular = NormalizarForma(original.Tú),
            TerceraPersonaSingular = NormalizarForma(original.Él),
            PrimeraPersonaPlural = NormalizarForma(original.Nosotros),
            SegundaPersonaPlural = NormalizarForma(original.Vosotros),
            TerceraPersonaPlural = NormalizarForma(original.Ellos),
            Gerundio = original.Gerundio,
            GerundioInglés = original.GerundioEnInglés,
            ParticipioPasado = original.ParticipioPasado,
            ParticipioPasadoInglés = original.ParticipioPasadoEnInglés
        };
    }

    private static string? NormalizarForma(string forma)
    {
        return string.IsNullOrWhiteSpace(forma) ? null : forma;
    }
}
