using How2Games.DataAccess.Data;
using How2Games.Domain.DB;
using How2Games.Services.GameServices;
using How2Games.Services.TagServices;
using How2Games.Services.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace How2Games.Controllers
{
    public class SearchBarController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IUserCRUDServices _userCRUDServices;
        private readonly ITagCRUDServices _tagCRUDServices;
        private readonly IGameCRUDServices _gameCRUDServices;
        private readonly SteamApiContext _steamdb;
        private readonly GamesContext _gamedb;
        private readonly SignInManager<How2GamesUser> _signInManager;






        public SearchBarController(ILogger<HomeController> logger, IUserCRUDServices userCRUDServices, ITagCRUDServices tagCRUDServices, IGameCRUDServices gameCRUDServices, SteamApiContext steamdb, GamesContext gamedb, SignInManager<How2GamesUser> signInManager)
        {
            _logger = logger;
            _userCRUDServices = userCRUDServices;
            _tagCRUDServices = tagCRUDServices;
            _gameCRUDServices = gameCRUDServices;
            _steamdb = steamdb;
            _gamedb = gamedb;
            _signInManager = signInManager;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string searchQuery)
        {

            if (!searchQuery.IsNullOrEmpty())
            {
                HashSet<string> searchResults = new HashSet<string>();

                var games1 = _steamdb.SteamGameIdName
                    .Where(x => x.Name.Contains(searchQuery))
                    .Take(5)
                    .Select(x => x.Name)
                    .ToList();  // Execute the query using _db context

                var games2 = _gamedb.Games
                    .Where(x => x.Name.Contains(searchQuery))
                    .Take(5)
                    .Select(x => x.Name)
                    .ToList();  // Execute the query using _gamedb context

                var combinedQuery = games1.Concat(games2).Distinct().Take(5);

                var GamesResults = combinedQuery.ToList();

                foreach (var name in GamesResults)
                {
                    searchResults.Add(name);
                }
                return PartialView("_SearchResults", searchResults);
            }
            return PartialView("_SearchResults", new HashSet<string>());
        }

    }
}
