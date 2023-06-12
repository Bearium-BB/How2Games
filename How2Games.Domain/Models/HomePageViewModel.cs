using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Domain.Models
{
    public class HomePageViewModel
    {
        public List<Game> MostViewedGames { get; set; }
        public List<Game> MostQuestionGame { get; set; }

        public HomePageViewModel(List<Game> Mvg, List<Game> Mqg) 
        {
            MostViewedGames= Mvg;
            MostQuestionGame= Mqg;
        }


    }
}
