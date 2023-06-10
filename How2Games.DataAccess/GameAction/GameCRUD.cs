using How2Games.DataAccess.Data;
using How2Games.DataAccess.TagAction;
using How2Games.Domain.DB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private readonly IPublisherTagCRUD _publisherTagCRUD;
        private readonly IDeveloperTagCRUD _developerTagCRUD;
        private readonly IGenreTagCRUD _genreTag;

        private readonly SteamApiContext _SteamApiContext;

        // Constructor
        public GameCRUD(GamesContext context, SteamApiContext steamApiContext, IPublisherTagCRUD publisherTagCRUD, IDeveloperTagCRUD developerTagCRUD, IGenreTagCRUD genreTag)
        {
            _context = context;
            _SteamApiContext = steamApiContext;
            _publisherTagCRUD = publisherTagCRUD;
            _developerTagCRUD= developerTagCRUD;
            _genreTag = genreTag;
        }

        // Insert a new game into the database
        public void Insert(string name, string shortDescription, string detailedDescription, string imgUrl, List<string> GenreTags, List<string> PublisherTags, List<string> DeveloperTags)
        {
            Game NewGame = new Game();
            NewGame.Name = name;
            NewGame.ShortDescription = shortDescription;
            NewGame.DetailedDescription = detailedDescription;
            NewGame.ImgUrl = imgUrl;

            // Check if each tag already exists in the database
            foreach (string tag in GenreTags)
            {
                bool tagExists = _context.GenreTags.Any(x => x.Text == tag);

                if (!tagExists)
                {
                    // Create a new tag if it doesn't exist
                    NewGame.GenreTags.Add(_genreTag.Create(tag));
                }
                else
                {
                    // Add the existing tag to the game
                    NewGame.GenreTags.Add(_context.GenreTags.FirstOrDefault(x => x.Text == tag));
                }
            }



            foreach (string tag in PublisherTags)
            {
                bool tagExists = _context.PublisherTags.Any(x => x.Text == tag);

                if (!tagExists)
                {
                    // Create a new tag if it doesn't exist
                    NewGame.PublisherTags.Add(_publisherTagCRUD.Create(tag));
                }
                else
                {
                    // Add the existing tag to the game
                    NewGame.PublisherTags.Add(_context.PublisherTags.FirstOrDefault(x => x.Text == tag));
                }
            }


            foreach (string tag in DeveloperTags)
            {
                bool tagExists = _context.DeveloperTags.Any(x => x.Text == tag);

                if (!tagExists)
                {
                    // Create a new tag if it doesn't exist
                    NewGame.DeveloperTags.Add(_developerTagCRUD.Create(tag));
                }
                else
                {
                    // Add the existing tag to the game
                    NewGame.DeveloperTags.Add(_context.DeveloperTags.FirstOrDefault(x => x.Text == tag));
                }
            }
            // Add the new game to the database
            _context.Games.Add(NewGame);
            _context.SaveChanges();
        }

        // Update an existing game in the database
        public void Update(int? id, string? name, string? detailedDescription, string? imgUrl, List<string>? tags)
        {
            Game? GameUpdate = _context.Games.Where(x => x.Id == id).FirstOrDefault();

            if (GameUpdate != null)
            {
                // Update the game's properties if provided
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

        // Read a game from the database by its ID
        public Game Read(int id)
        {
            Game? GameRead = _context.Games.Where(x => x.Id == id).FirstOrDefault();

            if (GameRead != null)
            {
                return GameRead;
            }

            // If the game doesn't exist, return an empty game
            return new Game();
        }

        // Delete a game from the database by its ID
        public void Delete(int id)
        {
            Game? GameDelete = _context.Games.Where(x => x.Id == id).FirstOrDefault();

            if (GameDelete != null)
            {
                // Remove the game from the database
                _context.Games.Remove(GameDelete);
                _context.SaveChanges();
            }
        }

        // Automatically create a game in the database using Steam API data
        public void AutoCreateSteamGameByAppId(string Name)
        {
            // Find the Steam game ID and name in the SteamApiContext
            var GameNameId = _SteamApiContext.SteamGameIdName.FirstOrDefault(x => x.Name == Name);

            if (GameNameId != null)
            {
                string task = "";
                task = Task.Run(() => MakeRequestAsync(GameNameId.SteamId)).Result;

                // Deserialize the Steam API response
                var obj = JsonConvert.DeserializeObject<dynamic>(task);
                var SteamGame = obj?.GetValue(GameNameId.SteamId)?.data;

                if (SteamGame != null)
                {
                    // Extract game information from the Steam API response
                    string detailedDescription = SteamGame["detailed_description"];
                    string shortDescription = SteamGame["short_description"];
                    string headerImage = SteamGame["header_image"];
                    string name = SteamGame["name"];

                    List<string> PublisherTags = new List<string>();
                    List<string> DeveloperTags = new List<string>();
                    List<string> GenreTags = new List<string>();


                    // Extract genre tags
                    var genres = SteamGame["genres"];
                    if (genres != null && genres.Type != JTokenType.Null)
                    {
                        foreach (var genre in genres)
                        {
                            var description = genre["description"]?.ToString();
                            if (!string.IsNullOrEmpty(description))
                            {
                                GenreTags.Add(description);
                            }
                        }
                    }

                    // Extract publisher tags
                    var publishers = SteamGame["publishers"];
                    if (publishers != null && publishers.Type != JTokenType.Null)
                    {
                        foreach (var publisher in publishers)
                        {
                            var publisherName = publisher?.ToString();
                            if (!string.IsNullOrEmpty(publisherName))
                            {
                                PublisherTags.Add(publisherName);
                            }
                        }
                    }

                    // Extract developer tags
                    var developers = SteamGame["developers"];
                    if (developers != null && developers.Type != JTokenType.Null)
                    {
                        foreach (var developer in developers)
                        {
                            var developerName = developer?.ToString();
                            if (!string.IsNullOrEmpty(developerName))
                            {
                                DeveloperTags.Add(developerName);
                            }
                        }
                    }

                    // Insert the new game into the database
                    Insert(
                        name,
                        shortDescription,
                        detailedDescription,
                        headerImage,
                        GenreTags,
                        PublisherTags,
                        DeveloperTags
                    );
                }
            }
        }

        // Create a new game object
        public Game Create(string name, string shortDescription, string detailedDescription, string imgUrl, List<string> tags)
        {
            Game NewGame = new Game();
            NewGame.Name = name;
            NewGame.ShortDescription = shortDescription;
            NewGame.DetailedDescription = detailedDescription;
            NewGame.ImgUrl = imgUrl;
            return NewGame;
        }

        // Make an asynchronous HTTP request
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
