namespace How2Games.Domain.DB
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Image> Images { get; set; } = new List<Image>();
        public ICollection<TextBox> TextBoxes { get; set; } = new List<TextBox>();



    }
}
