using Microsoft.EntityFrameworkCore;
using How2Games.Domain.DB;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace How2Games.DataAccess.Data
{
    public class GamesContext : IdentityDbContext<How2GamesUser>
    {
        public GamesContext()
        {
        }

        public GamesContext(DbContextOptions<GamesContext> options) : base(options) { }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<How2GamesUser> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<DeveloperTag> DeveloperTags { get; set; }
        public DbSet<PublisherTag> PublisherTags { get; set; }
        public DbSet<GenreTag> GenreTags { get; set; }


        //Add-Migration InitialCreate -Context GamesContext -OutputDir Migrations\GamesDbMigrations
        //Update-Database -Context GamesContext

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=How2Games;Integrated Security=True;Connect Timeout=1200;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", b => b.MigrationsAssembly("How2Games.DataAccess"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>()
                .HasMany(g => g.GenreTags)
                .WithMany(t => t.Games)
                .UsingEntity(j => j.ToTable("GameGenreTag"));

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>()
                .HasMany(g => g.DeveloperTags)
                .WithMany(t => t.Games)
                .UsingEntity(j => j.ToTable("GameDeveloperTag"));

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>()
                .HasMany(g => g.PublisherTags)
                .WithMany(t => t.Games)
                .UsingEntity(j => j.ToTable("GamePublisherTag"));
        }
    }
}