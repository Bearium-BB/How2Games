using Azure;
using How2Games.DataAccess.Data;
using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.DataAccess.TagAction
{
    public class DeveloperTagCRUD : IDeveloperTagCRUD
    {
        private readonly GamesContext _context;

        public DeveloperTagCRUD(GamesContext context)
        {
            _context = context;
        }

        public void Insert(string text)
        {
            if (_context.DeveloperTags.FirstOrDefault(x => x.Text == text) == null)
            {
                _context.DeveloperTags.Add(Create(text));
                _context.SaveChanges();
            }

        }

        public void Update(int id, string text)
        {
            DeveloperTag? TagUpdate = _context.DeveloperTags.Where(x => x.Id == id)
                .FirstOrDefault();

            if (TagUpdate != null)
            {
                TagUpdate.Text = text;
                _context.SaveChanges();
            }

        }
        public DeveloperTag Read(int id)
        {
            DeveloperTag? TagRead = _context.DeveloperTags.Where(x => x.Id == id)
                .FirstOrDefault();

            if (TagRead != null)
            {
                return TagRead;
            }
            return new DeveloperTag();
        }

        public void Delete(int id)
        {
            DeveloperTag? TagDelete = _context.DeveloperTags.Where(x => x.Id == id)
                .FirstOrDefault();
            if (TagDelete != null)
            {
                _context.DeveloperTags.Remove(TagDelete);
                _context.SaveChanges();

            }
        }
        public DeveloperTag Create(string text)
        {

            DeveloperTag NewTag = new DeveloperTag();
            NewTag.Text = text;
            return NewTag;
        }
    }
}
