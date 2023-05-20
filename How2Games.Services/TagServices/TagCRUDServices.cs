using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using How2Games.DataAccess.TagAction;
using How2Games.Domain.DB;

namespace How2Games.Services.TagServices
{
    public class TagCRUDServices : ITagCRUDServices
    {

        private readonly ITagCRUD _tagCRUD;

        public TagCRUDServices(ITagCRUD tagCRUD)
        {
            _tagCRUD = tagCRUD;
        }

        public void Insert(string text)
        {
            _tagCRUD.Insert(text);
        }

        public void Update(int id , string text)
        {
            _tagCRUD.Update(id,text);
        }

        public Tag Read(int id)
        {
            return _tagCRUD.Read(id);
        }

        public void Delete(int id)
        {
            _tagCRUD.Delete(id);
        }

        public Tag Create(string text)
        {
            return _tagCRUD.Create(text);
        }

    }
}
