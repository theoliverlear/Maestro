using System.ComponentModel.DataAnnotations.Schema;
using Maestro.Biblioteca.Api.Entidad.Conjugación.Propiedades;
using Maestro.Biblioteca.Universal.Modelos;

namespace Maestro.Biblioteca.Api.Entidad.Conjugación;

// TODO: Agregar base de datos columnas propiedades.

// TODO: Usar patrón constructor.

[Table("verbos_conjugados")]
public class VerboConjugado : EntidadIdentificableGenerada<int>
{
    /**
     * El verbo no conjugado.
     */
    public string Infinitivo { get; set; }

    /**
     * El verbo no conjugado en inglés.
     */
    public string InfinitivoInglés { get; set; }

    /**
     * La relación del hablante con lo que se dice.
     *
     * Modo Indicativo: Fáctico, objetivo.
     * Modo Subjuntivo: Emociones, deseos, hipótesis.
     * Modo Imperativo: Mandatos, órdenes.
     */
    public Ánimo Ánimo { get; set; }

    /**
     * La relación del hablante con lo que se dice en inglés.
     */
    public ÁnimoInglés ÁnimoInglés { get; set; }

    /**
     * Cuando algo está sucediendo.
     */
    public Tenso Tenso { get; set; }

    /**
     * Cuando algo está sucediendo en inglés.
     */
    public string TensoInglés { get; set; }

    /**
     * El verbo en inglés.
     */
    public string VerboInglés { get; set; }

    /**
     * Conjugado en primera persona singular.
     */
    public string PrimeraPersonaSingular { get; set; }

    /**
     * Conjugado en segunda persona singular.
     */
    public string SegundaPersonaSingular { get; set; }

    /**
     * Conjugado en tercera persona singular.
     */
    public string TerceraPersonaSingular { get; set; }

    /**
     * Conjugado en primera persona plural.
     */
    public string PrimeraPersonaPlural { get; set; }
    
    /**
     * Conjugado en segunda persona plural.
     */
    public string SegundaPersonaPlural { get; set; }

    /**
     * Conjugado en tercera persona plural.
     */
    public string TerceraPersonaPlural { get; set; }

    /**
     * El gerundio del verbo.
     */
    public string Gerundio { get; set; }

    /**
     * El gerundio del verbo en inglés.
     */
    public string GerundioInglés { get; set; }

    /**
     * El participio pasado del verbo.
     */
    public string ParticipioPasado { get; set; }

    /**
     * El participio pasado del verbo en inglés.
     */
    public string ParticipioPasadoInglés { get; set; }
}