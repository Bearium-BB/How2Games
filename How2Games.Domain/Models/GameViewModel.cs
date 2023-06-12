using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Domain.Models
{
    public class GameViewModel
    {
        public string Name { get; set; } = null!;
        public int Id { get; set; }

        public GameViewModel(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}
