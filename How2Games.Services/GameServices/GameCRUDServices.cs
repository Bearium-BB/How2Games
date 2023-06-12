using How2Games.DataAccess.GameAction;
using How2Games.DataAccess.TagAction;
using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Services.GameServices
{
    public class GameCRUDServices : IGameCRUDServices
    {
        private readonly IGameCRUD _gameCRUD;


        public GameCRUDServices(IGameCRUD gameCRUD)
        {
            _gameCRUD = gameCRUD;
        }

        public void Insert(string name, string shortDescription, string detailedDescription, string imgUrl, List<string> GenreTags, List<string> PublisherTags, List<string> DeveloperTags)
        {
            _gameCRUD.Insert(name, shortDescription, detailedDescription, imgUrl, GenreTags, PublisherTags, DeveloperTags);
        }

        public void Update(int? id, string? name, string? detailedDescription, string? imgUrl, List<string>? tags)
        {
            _gameCRUD.Update(id, name, detailedDescription, imgUrl, tags);
        }

        public Game Read(int id)
        {
            return _gameCRUD.Read(id);
        }

        public void Delete(int id)
        {
            _gameCRUD.Delete(id);
        }

        public void AutoCreateSteamGameByAppId(string Name)
        {
            _gameCRUD.AutoCreateSteamGameByAppId(Name);
        }

    }
}
