using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Domain.HelperFunctions
{
    public class GameHelperFunctions
    {
        // Create a new game object
        public Game Create(string name, string shortDescription, string detailedDescription, string imgUrl)
        {
            Game NewGame = new Game();
            NewGame.Name = name;
            NewGame.ShortDescription = shortDescription;
            NewGame.DetailedDescription = detailedDescription;
            NewGame.ImgUrl = imgUrl;
            return NewGame;
        }

    }
}
