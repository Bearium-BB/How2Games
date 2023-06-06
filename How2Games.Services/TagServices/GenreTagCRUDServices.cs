using How2Games.DataAccess.TagAction;
using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Services.TagServices
{
    public class GenreTagCRUDServices : IGenreTagCRUDServices
    {

        private readonly IGenreTagCRUD _genreTagCRUD;

        public GenreTagCRUDServices(IGenreTagCRUD genreTagCRUD)
        {
            _genreTagCRUD = genreTagCRUD;
        }

        public void Insert(string text)
        {
            _genreTagCRUD.Insert(text);
        }

        public void Update(int id, string text)
        {
            _genreTagCRUD.Update(id, text);
        }

        public GenreTag Read(int id)
        {
            return _genreTagCRUD.Read(id);
        }

        public void Delete(int id)
        {
            _genreTagCRUD.Delete(id);
        }

        public GenreTag Create(string text)
        {
            return _genreTagCRUD.Create(text);
        }
    }
}
