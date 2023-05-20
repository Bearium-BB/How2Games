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
        public ICollection<Tag> Tags { get; set;} = new List<Tag>();
    }
}
