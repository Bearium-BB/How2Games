using How2Games.DataAccess.User;
using How2Games.Domain.DB;
using How2Games.Services.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace How2Games.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserCRUDServices _userCRUDServices;
        private readonly UserManager<How2GamesUser> _userManager;
        private readonly SignInManager<How2GamesUser> _signInManager;
        

        public HomeController(ILogger<HomeController> logger, IUserCRUDServices userCRUDServices, UserManager<How2GamesUser> userManager, SignInManager<How2GamesUser> signInManager)
        {
            _logger = logger;
            _userCRUDServices= userCRUDServices;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public IActionResult Index()
        {
            FormUser user = new FormUser();

            
            return View(user);
        }


        [HttpPost]
        public IActionResult SignUp(FormUser user)
        {
            
                if (!_signInManager.IsSignedIn(User))
                {
                    _userCRUDServices.Insert(user.FirstName, user.LastName, user.Email, user.UserName, user.Password);

                    return View(user);
                }
            return View(user);
            
            

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}