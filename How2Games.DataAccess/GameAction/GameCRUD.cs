using How2Games.DataAccess.Data;
using How2Games.DataAccess.TagAction;
using How2Games.Domain.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace How2Games.DataAccess.GameAction
{
    public class GameCRUD : IGameCRUD
    {
        private readonly GamesContext _context;
        private readonly ITagCRUD _TagCRUD;
        private readonly SteamApiContext _SteamApiContext;


        public GameCRUD(GamesContext context, ITagCRUD tagCRUD, SteamApiContext steamApiContext)
        {
            _context = context;
            _TagCRUD = tagCRUD;
            _SteamApiContext = steamApiContext;
        }

        public void Insert(string name, string shortDescription,string detailedDescription,string imgUrl,List<string> tags)
        {
            Game NewGame = new Game();
            NewGame.Name = name;
            NewGame.ShortDescription = shortDescription;
            NewGame.DetailedDescription = detailedDescription;
            NewGame.ImgUrl = imgUrl;

            foreach(string tag in tags)
            {
                bool tagExists = _context.Tags.Any(x => x.Text == tag);

                if (!tagExists)
                {
                    NewGame.Tags.Add(_TagCRUD.Create(tag));
                }
                else
                {
                    NewGame.Tags.Add(_context.Tags.FirstOrDefault(x => x.Text == tag));
                }

            }
            _context.Games.Add(NewGame);
            _context.SaveChanges();
        }

        public void Update(int? id, string? name, string? detailedDescription, string? imgUrl, List<string>? tags)
        {
            Game? GameUpdate = _context.Games.Where(x => x.Id == id)
                .FirstOrDefault();

            if (GameUpdate != null)
            {

                if (imgUrl != null)
                {
                    GameUpdate.ImgUrl = imgUrl;

                }
                if (detailedDescription != null)
                {
                    GameUpdate.DetailedDescription = detailedDescription;

                }


                _context.SaveChanges();
            }

        }
        public Game Read(int id)
        {
            Game? GameRead = _context.Games.Where(x => x.Id == id)
                .FirstOrDefault();

            if (GameRead != null)
            {
                return GameRead;
            }
            return new Game();
        }

        public void Delete(int id)
        {
            Game? GameDelete = _context.Games.Where(x => x.Id == id)
                .FirstOrDefault();
            if (GameDelete != null)
            {
                _context.Games.Remove(GameDelete);
                _context.SaveChanges();
            }
        }

        public void AutoCreateSteamGameByAppId(string Name)
        {
            var GameNameId = _SteamApiContext.SteamGameIdName.FirstOrDefault(x => x.Name == Name);
            if (GameNameId != null)
            {
                string task = "";
                task = Task.Run(() => MakeRequestAsync(GameNameId.SteamId)).Result;
                var obj = JsonConvert.DeserializeObject<dynamic>(task);
                var SteamGame = obj?.GetValue(GameNameId.SteamId)?.data;
                if (SteamGame != null)
                {
                    string detailedDescription = SteamGame["detailed_description"];
                    string shortDescription = SteamGame["short_description"];
                    string headerImage = SteamGame["header_image"];
                    string name = SteamGame["name"];

                    List<string> tags = new List<string>();
                    foreach (var category in SteamGame["categories"])
                    {
                        string description = category["description"].ToString();
                        tags.Add(description);
                    }
                    foreach (var genre in SteamGame["genres"])
                    {
                        string description = genre["description"].ToString();
                        tags.Add(description);
                    }
                    foreach (var publisher in SteamGame["publishers"])
                    {
                        tags.Add(publisher.ToString());
                    }
                    foreach (var developer in SteamGame["developers"])
                    {
                        tags.Add(developer.ToString());
                    }
                    Insert(
                        name,
                        shortDescription,
                        detailedDescription,
                        headerImage,
                        tags
                        );

                }
               
            }
        }

        public Game Create(string name, string shortDescription, string detailedDescription, string imgUrl, List<string> tags)
        {
            Game NewGame = new Game();
            NewGame.Name = name;
            NewGame.ShortDescription = shortDescription;
            NewGame.DetailedDescription = detailedDescription;
            NewGame.ImgUrl = imgUrl;
            return NewGame;
        }

        public async Task<string> MakeRequestAsync(string AppId)
        {
            // Create a new HTTP client
            HttpClient client = new HttpClient();

            // Use the `await` keyword to make the request asynchronously
            HttpResponseMessage response = await client.GetAsync("https://store.steampowered.com/api/appdetails/?appids=" + AppId);

            // Return the response as a string
            return await response.Content.ReadAsStringAsync();
        }
    }
}
