using How2Games.Domain.DB;
using How2Games.Services.TagServices;
using How2Games.Services.User;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace How2Games.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserCRUDServices _userCRUDServices;
        private readonly ITagCRUDServices _tagCRUDServices;



        public HomeController(ILogger<HomeController> logger, IUserCRUDServices userCRUDServices, ITagCRUDServices tagCRUDServices)
        {
            _logger = logger;
            _userCRUDServices= userCRUDServices;
            _tagCRUDServices = tagCRUDServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            //_userCRUDServices.Insert("name","email","userName","test");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}