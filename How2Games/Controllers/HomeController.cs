using How2Games.DataAccess.Data;

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


namespace How2Games.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserCRUDServices _userCRUDServices;
        private readonly ITagCRUDServices _tagCRUDServices;
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

        public IActionResult Index()
        {
            FormUser user = new FormUser();
           

            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(FormUser user)
        {
            await _userCRUDServices.Insert(user.FullName, user.Email, user.UserName, user.Password);
            var result = await _signInManager.PasswordSignInAsync(_gamesContext.Users.FirstOrDefault(x=> x.UserName == user.UserName), user.Password,true , false);
            if (result.Succeeded)
            {

                return RedirectToAction("Index", "Home");
            }
            else
            {
                throw new ArgumentException("Invalid Log in attempt");
            
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(FormUser user)
        {
           

            //UserManager<How2GamesUser> userManager = new UserManager<How2GamesUser>(
            //    new UserStore<How2GamesUser>(new GamesContext()),
            //    Options.Create(options),
            //    new PasswordHasher<How2GamesUser>(),
            //    new IUserValidator<How2GamesUser>[0],
            //    new IPasswordValidator<How2GamesUser>[0],
            //    new UpperInvariantLookupNormalizer(),
            //    new IdentityErrorDescriber(),
            //    new ServiceCollection().BuildServiceProvider(),
            //    NullLogger<UserManager<How2GamesUser>>.Instance
            
            var testUser = _gamesContext.Users.FirstOrDefault(x => x.UserName == user.UserName);

            var result = await _signInManager.PasswordSignInAsync(testUser, user.Password, true, false);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                throw new ArgumentException("invalid log in attempt");
            }
            
            
        }
        [HttpPost]
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}