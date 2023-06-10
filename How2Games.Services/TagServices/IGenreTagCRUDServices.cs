using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Services.TagServices
{
    public interface IGenreTagCRUDServices
    {
        void Insert(string text);
        void Update(int id, string text);
        GenreTag Read(int id);
        void Delete(int id);
        GenreTag Create(string text);
    }
}
