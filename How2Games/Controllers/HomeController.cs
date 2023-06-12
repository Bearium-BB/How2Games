using How2Games.DataAccess.Data;
using How2Games.Domain.Models;
using How2Games.Domain.DB;
using How2Games.Services.GameServices;
using How2Games.Services.TagServices;
using How2Games.Services.User;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using How2Games.DataAccess.User;
using Microsoft.EntityFrameworkCore;

namespace How2Games.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserCRUDServices _userCRUDServices;
        private readonly IGameCRUDServices _gameCRUDServices;
        private readonly UserManager<How2GamesUser> _userManager;
        private readonly SignInManager<How2GamesUser> _signInManager;
        private readonly GamesContext _gamesContext;
        

        public HomeController(ILogger<HomeController> logger, IUserCRUDServices userCRUDServices, UserManager<How2GamesUser> userManager, SignInManager<How2GamesUser> signInManager, GamesContext gamesContext)

        {
            _logger = logger;
            _userCRUDServices = userCRUDServices;
            _userManager = userManager;
            _signInManager = signInManager;
            _gamesContext = gamesContext;


        }

        public async Task<IActionResult> Index()
        {
            List<Game> MostViewed = await _gamesContext.Games.Include(g => g.GenreTags).Include(g => g.DeveloperTags).OrderByDescending(g => g.ViewCount).Take(4).ToListAsync();
            List<Game> MostQuestions = await _gamesContext.Games.Include(g => g.GenreTags).Include(g => g.DeveloperTags).OrderByDescending(g => g.Questions.Count).Take(4).ToListAsync();

            return View(new HomePageViewModel(MostViewed, MostQuestions));
        }
        
        public async Task<IActionResult> HomePage()
        {
            List<Game> MostViewed = await _gamesContext.Games.Include(g => g.GenreTags).Include(g => g.DeveloperTags).OrderByDescending(g => g.ViewCount).Take(4).ToListAsync();
            List<Game> MostQuestions = await _gamesContext.Games.Include(g => g.GenreTags).Include(g => g.DeveloperTags).OrderByDescending(g => g.Questions.Count).Take(4).ToListAsync();
            
            return View(new HomePageViewModel(MostViewed, MostQuestions));
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(FormUser user)
                    
         {
            user.FullName = $"{user.FirstName} {user.LastName}";
            await _userCRUDServices.Insert(user.FullName, user.Email, user.UserName, user.Password);
            var test = _gamesContext.Users.FirstOrDefault(x=> x.UserName == user.UserName);
            var result = await _signInManager.PasswordSignInAsync(_gamesContext.Users.FirstOrDefault(x => x.UserName== user.UserName), user.Password,true,false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                throw new ArgumentException("");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(FormUser user)
        {
            var testUser = _gamesContext.Users.FirstOrDefault(x => x.UserName == user.UserName);
            var result = await _signInManager.PasswordSignInAsync(_gamesContext.Users.FirstOrDefault(x => x.UserName == user.UserName), user.Password, true, false);

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}