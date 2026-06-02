using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maestro.Entidad.Autorización;

[Table("tokens_de_actualización")]
public class TokenDeActualización : Identificable
{
    // TODO: Reemplazar pobre nombre de columna.
    [Required, Column("id_de_token", TypeName = "varchar(64)")]
    public string IdDeToken { get; set; } = string.Empty;

    [Required, Column("id_de_familia", TypeName = "varchar(64)")]
    public string IdDeFamilia { get; set; } = string.Empty;

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("huella_de_clave_dpop", TypeName = "varchar(128)")]
    public string? HuellaDeClaveDpop { get; set; }

    [Column("expira_en")]
    public DateTimeOffset ExpiraEn { get; set; }

    [Column("usado")]
    public bool Usado { get; set; }

    [Column("revocado")]
    public bool Revocado { get; set; }

    [NotMapped]
    public bool Expirado => DateTimeOffset.UtcNow >= this.ExpiraEn;
}
