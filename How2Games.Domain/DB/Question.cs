namespace How2Games.Domain.DB
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public string Text { get; set; }
        public int ViewCount { get; set; } = 0;
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<VoteQuestion> Votes { get; set; } = new List<VoteQuestion>();



    }
}
