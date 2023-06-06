using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Domain.DB
{
    public class PublisherTag
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<Game> Games { get; set; }
    }
}
