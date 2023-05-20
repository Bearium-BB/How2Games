using How2Games.DataAccess.Data;
using How2Games.Services.GameServices;
using How2Games.Services.TagServices;
using How2Games.Services.User;
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
        private readonly SteamApiContext _db;





        public SearchBarController(ILogger<HomeController> logger, IUserCRUDServices userCRUDServices, ITagCRUDServices tagCRUDServices, IGameCRUDServices gameCRUDServices, SteamApiContext db)
        {
            _logger = logger;
            _userCRUDServices = userCRUDServices;
            _tagCRUDServices = tagCRUDServices;
            _gameCRUDServices = gameCRUDServices;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchQuery)
        {
            if(!searchQuery.IsNullOrEmpty()){
                List<string> searchResults = new List<string>();
                var Games = _db.SteamGameIdName.Where(x => x.Name.Contains(searchQuery)).Take(5);
                foreach (var game in Games)
                {
                    searchResults.Add(game.Name);
                }
                return PartialView("_SearchResults", searchResults);
            }
            return PartialView("_SearchResults", new List<string>());
        }
    }
}
