using How2Games.DataAccess.Data;
using How2Games.Domain.ViewModels;
using How2Games.Domain.DB;
using How2Games.Services.GameServices;
using How2Games.Services.LogInService;
using How2Games.Services.TagServices;
using How2Games.Services.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using How2Games.Domain.Roles;

namespace How2Games.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserCRUDServices _userCRUDServices;
        private readonly IGameCRUDServices _gameCRUDServices;
        private readonly UserManager<How2GamesUser> _userManager;
        private readonly SignInManager<How2GamesUser> _signInManager;
        private readonly GamesContext _gamesContext;


        public UserController(ILogger<UserController> logger, IUserCRUDServices userCRUDServices, UserManager<How2GamesUser> userManager, SignInManager<How2GamesUser> signInManager, GamesContext gamesContext)

        {
            _logger = logger;
            _userCRUDServices = userCRUDServices;
            _userManager = userManager;
            _signInManager = signInManager;
            _gamesContext = gamesContext;


        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> SignUp(FormUser user)
        {
            user.FullName = user.FirstName + " " + user.LastName;
            await _userCRUDServices.Insert(user.FullName, user.Email, user.UserName, user.Password);
            var result = await _signInManager.PasswordSignInAsync(_gamesContext.Users.FirstOrDefault(x => x.UserName == user.UserName), user.Password, true, false);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Basic.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                throw new ArgumentException("Invalid Sign Up attempt");

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
            if (testUser != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(testUser, user.Password, false);

                if (result.Succeeded)
                {

                    await _signInManager.SignInAsync(testUser, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    throw new ArgumentException("Didnt Log in try again");

                }
            }
            else
            {
                throw new ArgumentException("No user found with that username");
            }


        }
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}