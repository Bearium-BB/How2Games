using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using How2Games.Domain.DB;

namespace How2Games.Domain.Models
{
    public class QuestionDataViewModel
    {
        public string Username { get; set; } = null!;
        public Question Question { get; set; } = null!;
        public List<KeyValuePair<string, Answer>> Answers { get; set; } = new List<KeyValuePair<string, Answer>>();
    }
}
