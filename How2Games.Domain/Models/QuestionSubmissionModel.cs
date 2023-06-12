using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Domain.Models
{
    public class QuestionSubmissionModel
    {
        public string QuestionText { get; set; } = null!;
        public int GameId { get; set; }
        public string Title { get; set; } = null!;
    }
}
