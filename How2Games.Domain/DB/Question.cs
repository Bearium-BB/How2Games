﻿namespace How2Games.Domain.DB
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public int GameId { get; set; }
        public string HTML { get; set; } = null!;
        public int ViewCount { get; set; } = 0;
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();


    }
}
