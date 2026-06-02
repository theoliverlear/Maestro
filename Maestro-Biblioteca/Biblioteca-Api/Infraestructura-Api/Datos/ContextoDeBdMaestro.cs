using Maestro.Entidad.Tarjeta;
using Maestro.Entidad.Autorización;
using Maestro.Entidad.Usuario;
using Microsoft.EntityFrameworkCore;

namespace Maestro.Datos;

public class ContextoDeBdMaestro : DbContext
{
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<BarajaDeCartas> BarajasDeCartas => Set<BarajaDeCartas>();
    public DbSet<Tarjeta> Tarjetas => Set<Tarjeta>();
    public DbSet<ContraseñaSegura> ContraseñasSeguras => Set<ContraseñaSegura>();
    public DbSet<TokenDeActualización> TokensDeActualización => Set<TokenDeActualización>();

    public ContextoDeBdMaestro(DbContextOptions<ContextoDeBdMaestro> options)
        : base(options)
    {

    }

    public DbSet<TEntidad> ObtenerConjuntoPorEntidad<TEntidad>() where TEntidad : class
    {
        return Set<TEntidad>();
    }

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
    }
}
