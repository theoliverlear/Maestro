using Maestro.Biblioteca.Api.Entidad.Autorización;
using Maestro.Biblioteca.Api.Entidad.Conjugación;
using Maestro.Biblioteca.Api.Entidad.Conjugación.Propiedades;
using Maestro.Biblioteca.Api.Entidad.Tarjeta;
using Maestro.Biblioteca.Api.Entidad.Usuario;
using Microsoft.EntityFrameworkCore;

namespace Maestro.Biblioteca.Universal.Componentes.Datos;

public class ContextoDeBdMaestro : DbContext
{
    public DbSet<Usuario> Usuarios => this.Set<Usuario>();
    public DbSet<BarajaDeCartas> BarajasDeCartas => this.Set<BarajaDeCartas>();
    public DbSet<Tarjeta> Tarjetas => this.Set<Tarjeta>();
    public DbSet<ContraseñaSegura> ContraseñasSeguras => this.Set<ContraseñaSegura>();
    public DbSet<TokenDeActualización> TokensDeActualización => this.Set<TokenDeActualización>();
    public DbSet<VerboConjugado> VerbosConjugados => this.Set<VerboConjugado>();

    public ContextoDeBdMaestro(DbContextOptions<ContextoDeBdMaestro> options)
        : base(options)
    {
    }

    public DbSet<TEntidad> ObtenerConjuntoPorEntidad<TEntidad>() where TEntidad : class
    {
        return this.Set<TEntidad>();
    }

    // TODO: Investiga soluciones más fluidas, tal vez con anotaciones.
    protected override void OnModelCreating(ModelBuilder constructorDeModelos)
    {
        constructorDeModelos.Entity<Usuario>()
            .HasMany(usuario => usuario.BarajasDeCartas)
            .WithOne(barajasDeCartas => barajasDeCartas.Usuario)
            .HasForeignKey(barajasDeCartas => barajasDeCartas.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        constructorDeModelos.Entity<Usuario>()
            .HasOne(usuario => usuario.ContraseñaSegura)
            .WithOne()
            .HasForeignKey<Usuario>(usuario => usuario.IdContraseñaSegura)
            .OnDelete(DeleteBehavior.Cascade);

        constructorDeModelos.Entity<BarajaDeCartas>()
            .HasMany(barajaDeCartas => barajaDeCartas.Cartas)
            .WithOne(tarjeta => tarjeta.BarajaDeCartas)
            .HasForeignKey(tarjeta => tarjeta.BarajaDeCartasId)
            .OnDelete(DeleteBehavior.Cascade);

        constructorDeModelos.Entity<TokenDeActualización>()
            .HasIndex(token => token.IdDeToken)
            .IsUnique();

        constructorDeModelos.Entity<TokenDeActualización>()
            .HasIndex(token => token.IdDeFamilia);

        constructorDeModelos.Entity<TokenDeActualización>()
            .HasIndex(token => token.IdUsuario);

        constructorDeModelos.Entity<VerboConjugado>()
            .Property(verbo => verbo.Ánimo)
            .HasConversion(
                ánimo => ánimo.CadenaDeÁnimo,
                cadena => Ánimo.DeCuerda(cadena));

        constructorDeModelos.Entity<VerboConjugado>()
            .Property(verbo => verbo.ÁnimoInglés)
            .HasConversion(
                ánimo => ánimo.CadenaDeÁnimoInglés,
                cadena => ÁnimoInglés.DeCuerda(cadena));

        constructorDeModelos.Entity<VerboConjugado>()
            .Property(verbo => verbo.Tenso)
            .HasConversion(
                tenso => tenso.CadenaDeTenso,
                cadena => Tenso.DeCuerda(cadena));

        constructorDeModelos.Entity<VerboConjugado>()
            .Property(verbo => verbo.TensoInglés)
            .HasConversion(
                tenso => tenso.CadenaDeTensoInglés,
                cadena => TensoInglés.DeCuerda(cadena));
    }
}
