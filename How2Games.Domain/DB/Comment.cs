﻿namespace How2Games.Domain.DB
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }

        public Comment() { }
    }
}
