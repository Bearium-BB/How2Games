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
using How2Games.Services.SearchBarServices;
using Microsoft.EntityFrameworkCore;

namespace How2Games.Controllers
{
    public class SearchBarController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IUserCRUDServices _userCRUDServices;
        private readonly IGameCRUDServices _gameCRUDServices;
        private readonly SteamApiContext _steamdb;
        private readonly GamesContext _gamedb;
        private readonly SignInManager<How2GamesUser> _signInManager;
        private readonly ISearchBarServices _searchBarServices;






        public SearchBarController(ILogger<HomeController> logger, 
            IUserCRUDServices userCRUDServices, 
            IGameCRUDServices gameCRUDServices,
            SteamApiContext steamdb,
            GamesContext gamedb,
            SignInManager<How2GamesUser> signInManager
            , ISearchBarServices searchBarServices)
        {
            _logger = logger;
            _userCRUDServices = userCRUDServices;
            _gameCRUDServices = gameCRUDServices;
            _steamdb = steamdb;
            _gamedb = gamedb;
            _signInManager = signInManager;
            _searchBarServices = searchBarServices;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string searchQuery)
        {
            if (!string.IsNullOrEmpty(searchQuery))
            {
                var searchResults = await _searchBarServices.GameSearchBar(searchQuery);

                return PartialView("_SearchResults", searchResults);
            }

            return PartialView("_SearchResults", new HashSet<string>());
        }

        [HttpPost]
        public async Task<IActionResult> SearchQuestion(string searchQuery,string gameName)
        {
            if (!string.IsNullOrEmpty(searchQuery))
            {
                var searchResults = await _searchBarServices.QuestionSearchBar(searchQuery, gameName);

                return PartialView("_GamePageSearchResults", searchResults);
            }

            return PartialView("_GamePageSearchResults", new HashSet<Question>());
        }

    }
}
