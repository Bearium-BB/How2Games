using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Domain.DB
{
    public class PostUpvote
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UpvoteId { get; set; }
        public PostUpvote() { }
    }
}
