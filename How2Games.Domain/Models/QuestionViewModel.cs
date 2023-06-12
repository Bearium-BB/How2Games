using How2Games.Domain.DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Domain.Models
{
    public class QuestionViewModel
    {
        public Game Game { get; set; } = null!;
        public List<Question> Questions { get; set; } = null!;
    }
}
