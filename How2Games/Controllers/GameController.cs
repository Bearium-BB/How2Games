using How2Games.DataAccess.Data;
using How2Games.Domain.DB;
using How2Games.Services.GameServices;
using How2Games.Services.TagServices;
using How2Games.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace How2Games.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserCRUDServices _userCRUDServices;
        private readonly IGameCRUDServices _gameCRUDServices;
        private readonly SteamApiContext _steamdb;
        private readonly GamesContext _gamedb;


        public GameController(ILogger<HomeController> logger, IUserCRUDServices userCRUDServices, IGameCRUDServices gameCRUDServices, SteamApiContext steamdb, GamesContext gamedb)
        {
            _logger = logger;
            _userCRUDServices = userCRUDServices;
            _gameCRUDServices = gameCRUDServices;
            _steamdb = steamdb;
            _gamedb = gamedb;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DoesGameExist(string GameName)
        {
            if (!_gamedb.Games.Any(x => x.Name == GameName))
            {
                if (_steamdb.SteamGameIdName.Any(x => x.Name == GameName))
                {
                    _gameCRUDServices.AutoCreateSteamGameByAppId(GameName);
                    return RedirectToAction("GamePage", "Game", new { GameName = GameName });
                }
            }
            return RedirectToAction("GamePage", "Game", new { GameName = GameName });

        }
        [Authorize(Roles = "Admin")]
        public IActionResult GamePage(string GameName)
        {
            var Game = _gamedb.Games.Include(x => x.GenreTags).FirstOrDefault(x => x.Name == GameName);
            return View(Game);
        }

        public IActionResult Create()
        {
            var question = new Question
            {
                Title = "Example Question",
                UserId = 1,
                Text = "This is an example question for ARK 2",
                ViewCount = 0
            };
            _gamedb.Games.Include(x => x.Questions).First(x => x.Name == "ARK 2").Questions.Add(question);

            _gamedb.SaveChanges();
            return View(new Game());
        }

        [HttpPost]
        public IActionResult SteamCreate()
        {

            return View();
        }

    }
}
