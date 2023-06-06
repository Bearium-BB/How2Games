﻿namespace How2Games.Domain.DB
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public string Text { get; set; }

    }
}
