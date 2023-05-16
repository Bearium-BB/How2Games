using How2Games.DataAccess.Data;
using How2Games.DataAccess.TagAction;
using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.DataAccess.GameAction
{
    public class GameCRUD
    {
        private readonly GamesContext _context;

        public GameCRUD(GamesContext context)
        {
            _context = context;
        }

        public void Insert(string detailedDescription,string imgUrl,List<string> tags)
        {
            Game NewGame = new Game();
            NewGame.DetailedDescription = detailedDescription;
            NewGame.ImgUrl = imgUrl;

            foreach(string tag in tags)
            {
                Tag NewTag = new Tag();
                NewTag.Text = tag;
                NewGame.Tags.Add(NewTag);
            }
            _context.Games.Add(NewGame);
            _context.SaveChanges();
        }

        public void Update(int id, string? text,string? imgUrl,string? detailedDescription)
        {
            Game? GameUpdate = _context.Games.Where(x => x.Id == id)
                .FirstOrDefault();

            if (GameUpdate != null)
            {

                if (imgUrl != null)
                {
                    GameUpdate.ImgUrl = imgUrl;

                }
                if (detailedDescription != null)
                {
                    GameUpdate.DetailedDescription = detailedDescription;

                }


                _context.SaveChanges();
            }

        }
        public Game Read(int id)
        {
            Game? GameRead = _context.Games.Where(x => x.Id == id)
                .FirstOrDefault();

            if (GameRead != null)
            {
                return GameRead;
            }
            return new Game();
        }

        public void Delete(int id)
        {
            Game? GameDelete = _context.Games.Where(x => x.Id == id)
                .FirstOrDefault();
            if (GameDelete != null)
            {
                _context.Games.Remove(GameDelete);
                _context.SaveChanges();
            }
        }
    }
}
