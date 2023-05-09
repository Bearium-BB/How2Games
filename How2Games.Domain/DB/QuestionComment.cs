namespace How2Games.Domain.DB
{
    public class QuestionComment
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int CommentId { get; set; }

        public QuestionComment() { }
    }
}
