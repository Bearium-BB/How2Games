using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Domain.DB
{
    public class AnswerDownvote
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public int DownvoteId { get; set; }
        public AnswerDownvote() { }
    }
}
