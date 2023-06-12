using Microsoft.EntityFrameworkCore;
using How2Games.Domain.DB;
using How2Games.Domain.Roles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;

namespace How2Games.DataAccess.Data
{
    public class GamesContext : IdentityDbContext<How2GamesUser>
    {
        public GamesContext()
        {
        }

        public GamesContext(DbContextOptions<GamesContext> options) : base(options) { }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<How2GamesUser> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<DeveloperTag> DeveloperTags { get; set; }
        public DbSet<PublisherTag> PublisherTags { get; set; }
        public DbSet<GenreTag> GenreTags { get; set; }
        public DbSet<VoteAnswer> VoteAnswer { get; set; }
        public DbSet<VoteQuestion> VoteQuestion { get; set; }



        //Add-Migration InitialCreate -Context GamesContext -OutputDir Migrations\GamesDbMigrations
        //Update-Database -Context GamesContext

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=How2Games;Integrated Security=True;Connect Timeout=1200;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; MultipleActiveResultSets=True;", b => b.MigrationsAssembly("How2Games.DataAccess"));
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
            base.OnModelCreating (modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(
                     new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" },
                new IdentityRole { Id = "3", Name = "Blacklist", NormalizedName = "BLACKLISTED" }
                );
            var newUser = new How2GamesUser
            {
                Id = "b9ac3d84-d8a8-4628-a254-be921b4b5630",
                FullName = "Brett Bowley",
                Email = "abc3@gmail.com",
                UserName = "BrettBowleyDotCom",
   

            };
            var newUser2 = new How2GamesUser
            {
                Id = "b8ac3d84-d8a8-4628-a254-be921b4b5630",
                FullName = "Lia Lee",
                Email = "abc2@gmail.com",
                UserName = "LiaLee",


            };

            var newUser3 = new How2GamesUser
            {
                Id = "b7ac3d84-d8a8-4628-a254-be921b4b5630",
                FullName = "Zack Zed",
                Email = "abc1@gmail.com",
                UserName = "ZackZad",


            };

            var newUser4 = new How2GamesUser
            {
                Id = "b6ac3d84-d8a8-4628-a254-be921b4b5630",
                FullName = "Hans KirbyLord",
                Email = "abc@gmail.com",
                UserName = "HansKirbyLord",


            };

            var passwordHasher = new PasswordHasher<How2GamesUser>();
            newUser3.PasswordHash = passwordHasher.HashPassword(newUser3, "Password1234!");

            modelBuilder.Entity<How2GamesUser>().HasData(newUser3);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = newUser3.Id, RoleId = "1" }
                );
        }

    }
}