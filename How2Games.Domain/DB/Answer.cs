namespace How2Games.Domain.DB
{
    public class Answer
    {
        public int Id { get; set; }
        public string HTML { get; set; }
        public string UserId { get; set; }
        public int QuestionId { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Upvote> UpVotes { get; set; } = new List<Upvote>();
        public ICollection<Downvote> DownVotes { get; set; } = new List<Downvote>();

    }
}
