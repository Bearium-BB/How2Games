using How2Games.DataAccess.Data;
using How2Games.Domain.DB;
using How2Games.Services.GameServices;
using How2Games.Services.LogInService;
using How2Games.Services.TagServices;
using How2Games.Services.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace How2Games.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserCRUDServices _userCRUDServices;
        private readonly ITagCRUDServices _tagCRUDServices;
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

        //Sign up 
       
        [HttpPost]
        //Prevent cross-site attacks 
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> SignUp(FormUser user)
        {
            //Grabs user's first name and last 
            user.FullName = user.FirstName + " " + user.LastName;
            //Inserts the new user into the database
            await _userCRUDServices.Insert(user.FullName, user.Email, user.UserName, user.Password);
            //Grabs the inserted user's information and then signs them in immidiately after registering
            var result = await _signInManager.PasswordSignInAsync(_gamesContext.Users.FirstOrDefault(x => x.UserName == user.UserName), user.Password, true, false);
            
            if (result.Succeeded)
            {
                //If the sign in succeeds, it will return them to the home page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //It will throw a new argument expeciton
                throw new ArgumentException("Invalid Sign Up attempt");

            }

        }
        //Login
        [HttpPost]
        //Prevent cross-site attacks 
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

            //Grabs the user's username and then returns the user model
            var testUser = _gamesContext.Users.FirstOrDefault(x => x.UserName == user.UserName);
            if (testUser != null)
            {
                //If the user is found then this will grab the user's password and make sure its the same as the user model from the server
                var result = await _signInManager.CheckPasswordSignInAsync(testUser, user.Password, false);

                if (result.Succeeded)
                {
                    //Finally if the result succeeds then it will sign them in and return them to homepage
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
        //Log out
        public IActionResult LogOut()
        {
            //It signs the user out and redirects them back to home page
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
