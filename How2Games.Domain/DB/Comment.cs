﻿namespace How2Games.Domain.DB
{
    public class Comment
    {
        public int Id { get; set; }
        public string HTML { get; set; }
        public int UserId { get; set; }
        public int AnswerId { get; set; }

    }
}
