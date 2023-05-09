using Microsoft.EntityFrameworkCore;
using How2Games.Domain.DB;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace How2Games.DataAccess.Data
{
    public class GamesContext : IdentityDbContext<How2GamesUser>
    {
        //Posts
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<PostText> PostTexts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostUpvote> PostUpvotes { get; set; }
        public DbSet<PostDownvote> PostDownvotes { get; set; }

        //Questions
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionImage> QuestionImages { get; set; }
        public DbSet<QuestionText> QuestionTexts { get; set; }
        public DbSet<QuestionComment> QuestionComments { get; set; }
        public DbSet<QuestionUpvote> QuestionUpvotes { get; set; }
        public DbSet<QuestionDownvote> QuestionDownvotes { get; set; }

        //Comments
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentUpvote> CommentUpvotes { get; set; }
        public DbSet<CommentDownvote> CommentDownvotes { get; set; }

        //Answers
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerUpvote> AnswerUpvotes { get; set; }
        public DbSet<AnswerDownvote> AnswerDownvotes { get; set; }

        //Post and Question Content
        public DbSet<Image> Images { get; set; }
        public DbSet<TextBox> Texts { get; set; }
        public DbSet<Upvote> Upvotes { get; set; }
        public DbSet<Downvote> Downvotes { get; set; }

        //User
        public DbSet<How2GamesUser> Users { get; set; }


        public GamesContext(DbContextOptions<GamesContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=How2Games;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",b => b.MigrationsAssembly("How2Games.DataAccess"));
        }
    }
}
