using How2Games.DataAccess.Data;
using How2Games.Domain.DB;
using How2Games.Services.GameServices;
using How2Games.Services.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.Identity;
using How2Games.Domain.Models;

namespace How2Games.Controllers
{

    public class PostsController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserCRUDServices _userCRUDServices;
        private readonly IGameCRUDServices _gameCRUDServices;
        private readonly Microsoft.AspNetCore.Identity.UserManager<How2GamesUser> _userManager;
        private readonly SignInManager<How2GamesUser> _signInManager;
        private readonly GamesContext _gamesContext;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager;


        public PostsController(ILogger<UserController> logger, IUserCRUDServices userCRUDServices, Microsoft.AspNetCore.Identity.UserManager<How2GamesUser> userManager, SignInManager<How2GamesUser> signInManager, GamesContext gamesContext, Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager)

        {
            _logger = logger;
            _userCRUDServices = userCRUDServices;
            _userManager = userManager;
            _signInManager = signInManager;
            _gamesContext = gamesContext;
            _roleManager = roleManager;
        }

        public IActionResult CreateQuestion(int gameId, string gameName)
        {
            GameViewModel gameViewModel = new GameViewModel(gameName, gameId);
            return View(gameViewModel);
        }
        [HttpPost]
        public JsonResult UploadFile(string fileName, IFormFile file)
        {
            ImageUploadResponseModel responseModel = new ImageUploadResponseModel();

            if (file != null && file.Length > 0)
            {
                // Set the path to save the file within the wwwroot/Images folder
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", fileName);

                // Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // Check if the file exists
                if (System.IO.File.Exists(filePath))
                {
                    // Build the relative URL of the saved image
                    string relativePath = "/Images/" + fileName;

                    responseModel.Success = true;
                    responseModel.FilePath = relativePath;
                }
                else
                {
                    responseModel.Success = false;
                    responseModel.Error = "Failed to save the file.";
                }
            }
            else
            {
                responseModel.Success = false;
                responseModel.Error = "No file was received.";
            }

            return Json(responseModel);
        }


        [HttpPost]
        public JsonResult SubmitQuestion(string questionText, int gameId, string title)
        {
            ImageUploadResponseModel responseModel = new ImageUploadResponseModel();

            Question question = new Question();
            question.HTML = questionText;
            question.ViewCount = 0;
            question.GameId = gameId;
            question.Title = title;
            string userId = "";
            if (_signInManager.IsSignedIn(User))
            {
                userId = User.Identity.GetUserId();
            }
            question.UserId = userId;

            Console.WriteLine("Title: " + question.Title);
            Console.WriteLine("GameId: " + question.GameId);
            Console.WriteLine("HTML: " + question.HTML);

            /*            _gamesContext.Questions.Add(question);
                        _gamesContext.SaveChanges();

                        foreach (var v in _gamesContext.Questions)
                        {
                            Console.WriteLine(v.Title);
                        }*/
            return Json(responseModel);
        }
    }
}
