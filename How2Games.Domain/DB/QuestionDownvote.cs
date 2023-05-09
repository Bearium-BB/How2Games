using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Domain.DB
{
    public class QuestionDownvote
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int DownvoteId { get; set; }
        public QuestionDownvote() { }
    }
}
