using How2Games.DataAccess.TagAction;
using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Services.TagServices
{
    public class DeveloperTagCRUDServices : IDeveloperTagCRUDServices
    {
        private readonly IDeveloperTagCRUD _developerTagCRUD;

        public DeveloperTagCRUDServices(IDeveloperTagCRUD developerTagCRUD)
        {
            _developerTagCRUD = _developerTagCRUD;
        }

        public void Insert(string text)
        {
            _developerTagCRUD.Insert(text);
        }

        public void Update(int id, string text)
        {
            _developerTagCRUD.Update(id, text);
        }

        public DeveloperTag Read(int id)
        {
            return _developerTagCRUD.Read(id);
        }

        public void Delete(int id)
        {
            _developerTagCRUD.Delete(id);
        }

        public DeveloperTag Create(string text)
        {
            return _developerTagCRUD.Create(text);
        }
    }
}
