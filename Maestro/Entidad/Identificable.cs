using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maestro.Entidad;

public abstract class Identificable
{
    [Key, Column("id")]
    public int Id { get; set; }
}