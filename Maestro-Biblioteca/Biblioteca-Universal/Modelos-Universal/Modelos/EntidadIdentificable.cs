using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maestro.Biblioteca.Universal.Modelos;

public abstract class EntidadIdentificable<TId> : Identificable<TId>
{
    [Key, Column("id")]
    public override TId Id { get; set; } = default!;
}
