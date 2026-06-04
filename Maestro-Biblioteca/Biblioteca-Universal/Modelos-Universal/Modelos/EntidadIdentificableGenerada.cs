using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maestro.Biblioteca.Universal.Modelos;

public abstract class EntidadIdentificableGenerada<TId> : Identificable<TId>
{
    [Key, Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override TId Id { get; set; } = default!;
}
