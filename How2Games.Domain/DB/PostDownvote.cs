using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Domain.DB
{
    public class PostDownvote
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int DownvoteId { get; set; }
        public PostDownvote() { }
    }
}
