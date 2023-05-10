using How2Games.DataAccess.Data;
using How2Games.Domain.DB;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using How2Games.Domain.DB;

namespace How2Games.DataAccess.TagAction
{
    public class TagCRUD : ITagCRUD
    {
        private readonly GamesContext _context;

        public TagCRUD(GamesContext context)
        {
            _context = context;
        }

        public void Insert(string text)
        {
            Tag NewTag = new Tag();
            NewTag.Text = text;
            _context.Tags.Add(NewTag);
            _context.SaveChanges();
        }

        public void Update(int id,string text)
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
