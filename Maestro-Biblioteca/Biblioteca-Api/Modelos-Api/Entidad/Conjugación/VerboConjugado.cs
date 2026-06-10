using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Maestro.Biblioteca.Api.Entidad.Conjugación.Propiedades;
using Maestro.Biblioteca.Universal.Modelos;

namespace Maestro.Biblioteca.Api.Entidad.Conjugación;

// TODO: Usar patrón constructor.

[Table("verbos_conjugados")]
public class VerboConjugado : EntidadIdentificableGenerada<int>
{
    private const string TipoTextoCorto = "varchar(250)";

    /**
     * El verbo no conjugado.
     */
    [Required]
    [Column("infinitivo", TypeName = TipoTextoCorto)]
    public string Infinitivo { get; set; }

    /**
     * El verbo no conjugado en inglés.
     */
    [Required]
    [Column("infinitivo_inglés", TypeName = TipoTextoCorto)]
    public string InfinitivoInglés { get; set; }

    /**
     * La relación del hablante con lo que se dice.
     *
     * Modo Indicativo: Fáctico, objetivo.
     * Modo Subjuntivo: Emociones, deseos, hipótesis.
     * Modo Imperativo: Mandatos, órdenes.
     */
    [Required]
    [Column("ánimo", TypeName = TipoTextoCorto)]
    public Ánimo Ánimo { get; set; }

    /**
     * La relación del hablante con lo que se dice en inglés.
     */
    [Required]
    [Column("ánimo_inglés", TypeName = TipoTextoCorto)]
    public ÁnimoInglés ÁnimoInglés { get; set; }

    /**
     * Cuando algo está sucediendo.
     */
    [Required]
    [Column("tenso", TypeName = TipoTextoCorto)]
    public Tenso Tenso { get; set; }

    /**
     * Cuando algo está sucediendo en inglés.
     */
    [Required]
    [Column("tenso_inglés", TypeName = TipoTextoCorto)]
    public TensoInglés TensoInglés { get; set; }

    /**
     * El verbo en inglés.
     */
    [Required]
    [Column("verbo_inglés", TypeName = TipoTextoCorto)]
    public string VerboInglés { get; set; }

    /**
     * Conjugado en primera persona singular.
     */
    [Column("primera_persona_singular", TypeName = TipoTextoCorto)]
    public string? PrimeraPersonaSingular { get; set; }

    /**
     * Conjugado en segunda persona singular.
     */
    [Column("segunda_persona_singular", TypeName = TipoTextoCorto)]
    public string? SegundaPersonaSingular { get; set; }

    /**
     * Conjugado en tercera persona singular.
     */
    [Column("tercera_persona_singular", TypeName = TipoTextoCorto)]
    public string? TerceraPersonaSingular { get; set; }

    /**
     * Conjugado en primera persona plural.
     */
    [Column("primera_persona_plural", TypeName = TipoTextoCorto)]
    public string? PrimeraPersonaPlural { get; set; }
    
    /**
     * Conjugado en segunda persona plural.
     */
    [Column("segunda_persona_plural", TypeName = TipoTextoCorto)]
    public string? SegundaPersonaPlural { get; set; }

    /**
     * Conjugado en tercera persona plural.
     */
    [Column("tercera_persona_plural", TypeName = TipoTextoCorto)]
    public string? TerceraPersonaPlural { get; set; }

    /**
     * El gerundio del verbo.
     */
    [Required]
    [Column("gerundio", TypeName = TipoTextoCorto)]
    public string Gerundio { get; set; }

    /**
     * El gerundio del verbo en inglés.
     */
    [Required]
    [Column("gerundio_inglés", TypeName = TipoTextoCorto)]
    public string GerundioInglés { get; set; }

    /**
     * El participio pasado del verbo.
     */
    [Required]
    [Column("participio_pasado", TypeName = TipoTextoCorto)]
    public string ParticipioPasado { get; set; }

    /**
     * El participio pasado del verbo en inglés.
     */
    [Required]
    [Column("participio_pasado_inglés", TypeName = TipoTextoCorto)]
    public string ParticipioPasadoInglés { get; set; }

    public VerboConjugado()
    {
        this.Infinitivo = string.Empty;
        this.InfinitivoInglés = string.Empty;
        this.Ánimo = new Ánimo(string.Empty);
        this.ÁnimoInglés = new ÁnimoInglés(string.Empty);
        this.Tenso = new Tenso(string.Empty);
        this.TensoInglés = new TensoInglés(string.Empty);
        this.VerboInglés = string.Empty;
        this.PrimeraPersonaSingular = string.Empty;
        this.SegundaPersonaSingular = string.Empty;
        this.TerceraPersonaSingular = string.Empty;
        this.PrimeraPersonaPlural = string.Empty;
        this.SegundaPersonaPlural = string.Empty;
        this.TerceraPersonaPlural = string.Empty;
        this.Gerundio = string.Empty;
        this.GerundioInglés = string.Empty;
        this.ParticipioPasado = string.Empty;
        this.ParticipioPasadoInglés = string.Empty;
    }
}
