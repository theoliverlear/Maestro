using Maestro.Entidad.Tarjeta;
using Maestro.Entidad.Usuario;
using Microsoft.EntityFrameworkCore;

namespace Maestro.Datos;

public class ContextoDeBdMaestro : DbContext
{
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<BarajaDeCartas> BarajasDeCartas => Set<BarajaDeCartas>();
    public DbSet<Tarjeta> Tarjetas => Set<Tarjeta>();

    public ContextoDeBdMaestro(DbContextOptions<ContextoDeBdMaestro> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder constructorDeModelos)
    {
        constructorDeModelos.Entity<Usuario>()
            .HasOne(usuario => usuario.BarajaDeCartas)
            .WithOne(barajaDeCartas => barajaDeCartas.Usuario)
            .HasForeignKey<BarajaDeCartas>(barajaDeCartas => barajaDeCartas.Id)
            .OnDelete(DeleteBehavior.Cascade);

        constructorDeModelos.Entity<BarajaDeCartas>()
            .HasMany(barajaDeCartas => barajaDeCartas.Cartas)
            .WithOne(tarjeta => tarjeta.BarajaDeCartas)
            .HasForeignKey(tarjeta => tarjeta.BarajaDeCartasId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}