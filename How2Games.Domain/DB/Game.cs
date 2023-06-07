using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Domain.DB
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
        public string ImgUrl { get; set; }
        public int ViewCount { get; set; } = 0;
        public ICollection<GenreTag> GenreTags { get; set;} = new List<GenreTag>();
        public ICollection<DeveloperTag> DeveloperTags { get; set; } = new List<DeveloperTag>();
        public ICollection<PublisherTag> PublisherTags { get; set; } = new List<PublisherTag>();
        public ICollection<Question> Questions { get; set; } = new List<Question>();


    }
}
