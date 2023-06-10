using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Services.TagServices
{
    public interface IDeveloperTagCRUDServices
    {
        void Insert(string text);
        void Update(int id, string text);
        DeveloperTag Read(int id);
        void Delete(int id);
        DeveloperTag Create(string text);
    }
}
