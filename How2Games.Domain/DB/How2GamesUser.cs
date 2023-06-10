using How2Games.Domain.Roles;
using Microsoft.AspNetCore.Identity;

namespace How2Games.Domain.DB
{
    public class How2GamesUser : IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
    
}
