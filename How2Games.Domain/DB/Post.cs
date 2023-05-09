namespace How2Games.Domain.DB
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }

        public Post() { }
    }
}
