using How2Games.Domain.DB;
using How2Games.Services.User;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace How2Games.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserCRUDServices _userCRUDServices;


        public HomeController(ILogger<HomeController> logger, IUserCRUDServices userCRUDServices)
        {
            _logger = logger;
            _userCRUDServices= userCRUDServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            _userCRUDServices.Insert();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}