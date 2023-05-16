using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.DataAccess.GameAction
{
    public interface IGameCRUD
    {
        void Insert(string detailedDescription, string imgUrl);
        void Update(int id, string? text, string? imgUrl, string? detailedDescription);
        Game Read(int id);
        void Delete(int id);
    }
}
