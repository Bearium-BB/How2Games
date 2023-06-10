using How2Games.DataAccess.TagAction;
using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Services.TagServices
{
    public class PublisherTagCRUDServices : IPublisherTagCRUDServices
    {
        private readonly IPublisherTagCRUD _publisherTagCRUD;

        public PublisherTagCRUDServices(IPublisherTagCRUD publisherTagCRUD)
        {
            _publisherTagCRUD = publisherTagCRUD;
        }

        public void Insert(string text)
        {
            _publisherTagCRUD.Insert(text);
        }

        public void Update(int id, string text)
        {
            _publisherTagCRUD.Update(id, text);
        }

        public PublisherTag Read(int id)
        {
            return _publisherTagCRUD.Read(id);
        }

        public void Delete(int id)
        {
            _publisherTagCRUD.Delete(id);
        }

        public PublisherTag Create(string text)
        {
            return _publisherTagCRUD.Create(text);
        }
    }
}
