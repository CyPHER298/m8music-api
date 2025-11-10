using M8MusicAPI.Infrastructure.Persistence.Models;
using M8MusicAPI.Mappings;
using M8MusicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace M8MusicAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Avaliacao> Avaliacoes => Set<Avaliacao>();
    public DbSet<Music> Musics => Set<Music>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MusicMapping());
        modelBuilder.ApplyConfiguration(new AvaliacaoMapping());
        modelBuilder.ApplyConfiguration(new ClienteMapping());
        modelBuilder.Entity<Avaliacao>()
            .HasOne(a => a.Cliente) 
            .WithMany(c => c.Avaliacoes)
            .HasForeignKey(a => a.ClienteId);
        
        modelBuilder.Entity<Avaliacao>()
            .HasOne(a => a.Music) 
            .WithMany(c => c.avaliacoes)
            .HasForeignKey(a => a.IdMusic);

        base.OnModelCreating(modelBuilder);
    }
}