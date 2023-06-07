using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Services.GameServices
{
    public interface IGameCRUDServices
    {
        public void Insert(string name, string shortDescription, string detailedDescription, string imgUrl, List<string> GenreTags, List<string> PublisherTags, List<string> DeveloperTags);
        void Update(int? id, string? name, string? detailedDescription, string? imgUrl, List<string>? tags);
        Game Read(int id);
        void Delete(int id);
        Game Create(string name, string shortDescription, string detailedDescription, string imgUrl, List<string> tags);
        void AutoCreateSteamGameByAppId(string Name);
    }
}
