namespace How2Games.Domain.DB
{
    public class Answer
    {
        public int Id { get; set; }
        public string HTML { get; set; }
        public string UserId { get; set; }
        public int QuestionId { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<VoteAnswer> Votes { get; set; } = new List<VoteAnswer>();


    }
}
