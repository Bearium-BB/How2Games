using Microsoft.EntityFrameworkCore;
using How2Games.Domain.DB;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace How2Games.DataAccess.Data
{
    public class GamesContext : IdentityDbContext<How2GamesUser>
    {
        public GamesContext(DbContextOptions<GamesContext> options) : base(options) { }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<PostText> PostTexts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionComment> QuestionComments { get; set; }
        public DbSet<QuestionImage> QuestionImages { get; set; }
        public DbSet<QuestionText> QuestionTexts { get; set; }
        public DbSet<TextBox> Texts { get; set; }
        public DbSet<How2GamesUser> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=How2Games;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",b => b.MigrationsAssembly("How2Games.DataAccess"));
        }
    }
}
