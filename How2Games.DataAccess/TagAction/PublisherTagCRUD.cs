using How2Games.DataAccess.Data;
using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.DataAccess.TagAction
{
    public class PublisherTagCRUD : IPublisherTagCRUD
    {
        private readonly GamesContext _context;

        public PublisherTagCRUD(GamesContext context)
        {
            _context = context;
        }

        public void Insert(string text)
        {
            if (_context.PublisherTags.FirstOrDefault(x => x.Text == text) == null)
            {
                _context.PublisherTags.Add(Create(text));
                _context.SaveChanges();
            }

        }

        public void Update(int id, string text)
        {
            PublisherTag? TagUpdate = _context.PublisherTags.Where(x => x.Id == id)
                .FirstOrDefault();

            if (TagUpdate != null)
            {
                TagUpdate.Text = text;
                _context.SaveChanges();
            }

        }
        public PublisherTag Read(int id)
        {
            PublisherTag? TagRead = _context.PublisherTags.Where(x => x.Id == id)
                .FirstOrDefault();

            if (TagRead != null)
            {
                return TagRead;
            }
            return new PublisherTag();
        }

        public void Delete(int id)
        {
            PublisherTag? TagDelete = _context.PublisherTags.Where(x => x.Id == id)
                .FirstOrDefault();
            if (TagDelete != null)
            {
                _context.PublisherTags.Remove(TagDelete);
                _context.SaveChanges();

            }
        }
        public PublisherTag Create(string text)
        {

            PublisherTag NewTag = new PublisherTag();
            NewTag.Text = text;
            if (NewTag.Text == null)
            {
                throw new ArgumentNullException(NewTag.Text);
            }
            return NewTag;
        }
    }
}
