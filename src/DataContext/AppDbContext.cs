using AnimeTV.Models.Anime;
using AnimeTV.Models.Usuario;
using Microsoft.EntityFrameworkCore;

namespace AnimeTV.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<AnimeEpisodio> Episodios { get; set; }
        public DbSet<AnimeTemporada> Temporadas { get; set; }
        public DbSet<AnimeCategoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anime>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Anime>()
                .HasMany(a => a.Episodios)
                .WithOne(e => e.Anime)
                .HasForeignKey(e => e.AnimeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Anime>()
                .HasMany(a => a.Temporadas)
                .WithOne(t => t.Anime)
                .HasForeignKey(t => t.AnimeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Anime>()
                .HasMany(a => a.Categorias)
                .WithOne(c => c.Anime)
                .HasForeignKey(c => c.AnimeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AnimeEpisodio>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<AnimeTemporada>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<AnimeCategoria>()
                .HasKey(c => new { c.AnimeId, c.Categoria });


            base.OnModelCreating(modelBuilder);
        }
    }
}
