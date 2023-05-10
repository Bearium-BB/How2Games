using How2Games.DataAccess.Data;
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

        public void Insert(string detailedDescription)
        {
            Game NewGame = new Game();
            NewGame.DetailedDescription = detailedDescription;
            NewGame.ImgUrl = "Url";
            _context.Games.Add(NewGame);
            _context.SaveChanges();
        }

        public void Update(int id, string text)
        {
            Tag? TagUpdate = _context.Tags.Where(x => x.Id == id)
                .FirstOrDefault();

            if (TagUpdate != null)
            {
                TagUpdate.Text = text;
                _context.SaveChanges();
            }

        }
        public Tag Read(int id)
        {
            Tag? TagRead = _context.Tags.Where(x => x.Id == id)
                .FirstOrDefault();

            if (TagRead != null)
            {
                return TagRead;
            }
            return new Tag();
        }

        public void Delete(int id)
        {
            Tag? TagDelete = _context.Tags.Where(x => x.Id == id)
                .FirstOrDefault();
            if (TagDelete != null)
            {
                _context.Tags.Remove(TagDelete);
                _context.SaveChanges();

            }
        }
    }
}
