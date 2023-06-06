using How2Games.DataAccess.Data;
using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.DataAccess.TagAction
{
    public class GenreTagCRUD
    {
        private readonly GamesContext _context;

        public GenreTagCRUD(GamesContext context)
        {
            _context = context;
        }

        public void Insert(string text)
        {
            if (_context.GenreTags.FirstOrDefault(x => x.Text == text) == null)
            {
                _context.GenreTags.Add(Create(text));
                _context.SaveChanges();
            }

        }

        public void Update(int id, string text)
        {
            GenreTag? TagUpdate = _context.GenreTags.Where(x => x.Id == id)
                .FirstOrDefault();

            if (TagUpdate != null)
            {
                TagUpdate.Text = text;
                _context.SaveChanges();
            }

        }
        public GenreTag Read(int id)
        {
            GenreTag? TagRead = _context.GenreTags.Where(x => x.Id == id)
                .FirstOrDefault();

            if (TagRead != null)
            {
                return TagRead;
            }
            return new GenreTag();
        }

        public void Delete(int id)
        {
            GenreTag? TagDelete = _context.GenreTags.Where(x => x.Id == id)
                .FirstOrDefault();
            if (TagDelete != null)
            {
                _context.GenreTags.Remove(TagDelete);
                _context.SaveChanges();

            }
        }
        public GenreTag Create(string text)
        {

            GenreTag NewTag = new GenreTag();
            NewTag.Text = text;
            return NewTag;
        }
    }
}
