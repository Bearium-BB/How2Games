using How2Games.DataAccess.Data;
using How2Games.Domain.DB;
using How2Games.Domain.Models;
using How2Games.Domain.Form;
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
        private readonly Microsoft.AspNetCore.Identity.UserManager<How2GamesUser> _userManager;


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

        public IActionResult GamePage(string GameName)
        {
            var Game = _gamedb.Games.Include(x => x.GenreTags).FirstOrDefault(x => x.Name == GameName);
            if (Game != null)
            {
                List<Question> questions = _gamedb.Games.Include(x => x.Questions).FirstOrDefault(x => x.Name == GameName).Questions.ToList();
                QuestionViewModel questionViewModel = new QuestionViewModel();
                Game.ViewCount++;
                _gamedb.SaveChanges();
                questionViewModel.Game = Game;
                questionViewModel.Questions = questions;
                return View(questionViewModel);
            }
            return RedirectToAction("Error", "Home", new {gameName = GameName });

        }

        [HttpPost]
        public IActionResult GamePage(int gameId, string gameName)
        {
            return RedirectToAction("CreateQuestion", "Posts", new { gameId = gameId, gameName = gameName });
        }

        public IActionResult Create()
        {
            return View(new FormGameCreate());
        }

        [HttpPost]
        public IActionResult Create(FormGameCreate formGameCreate)
        {
            var GenreTags = formGameCreate.GenreTags.Split(",").ToList();
            var PublisherTags = formGameCreate.PublisherTags.Split(",").ToList();
            var DeveloperTags = formGameCreate.DeveloperTags.Split(",").ToList();

            _gameCRUDServices.Insert(formGameCreate.Name, formGameCreate.ShortDescription, "", formGameCreate.ImgUrl, GenreTags, PublisherTags, DeveloperTags);
            return RedirectToAction("GamePage", "Game", new { GameName = formGameCreate.Name });
        }


        [HttpPost]
        public IActionResult SteamCreate()
        {

            return View();
        }
    }
}
