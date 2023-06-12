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
            JsonResponseModel responseModel = new JsonResponseModel();

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
            JsonResponseModel responseModel = new JsonResponseModel();

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

            _gamesContext.Questions.Add(question);
            _gamesContext.SaveChanges();

            return Json(responseModel);
        }

        public IActionResult Question(int id)
        {
            QuestionDataViewModel questionData = new QuestionDataViewModel();
            Question question = _gamesContext.Questions.FirstOrDefault(x => x.Id == id);
            List<Answer> answers = _gamesContext.Answers.Where(x => x.QuestionId == question.Id).ToList();
            List<KeyValuePair<string, Answer>> answerKvps = new List<KeyValuePair<string, Answer>>();

            for (int i = 0; i < answers.Count; i++)
            {
                KeyValuePair<string, Answer> kvp = new KeyValuePair<string, Answer>();
                foreach (var v in _userManager.Users)
                {
                    if (v.Id == answers[i].UserId)
                    {
                        kvp = new KeyValuePair<string, Answer>(v.UserName, answers[i]);
                        answerKvps.Add(kvp);
                    }
                }
            }

            foreach (var v in _gamesContext.Questions)
            {
                if (v.Id == question.Id)
                {
                    v.ViewCount++;
                    _gamesContext.SaveChanges();
                }
            }
            questionData.Question = question;
            questionData.Username = _userManager.Users.FirstOrDefault(x => x.Id == question.UserId).UserName;
            questionData.Answers = answerKvps;
            return View(questionData);
        }

        [HttpPost]
        public JsonResult CreateAnswer(string answerText, int questionId)
        {
            JsonResponseModel responseModel = new JsonResponseModel();
            Answer answer = new Answer();

            answer.HTML = answerText;
            answer.QuestionId = questionId;
            string userId = "";
            if (_signInManager.IsSignedIn(User))
            {
                userId = User.Identity.GetUserId();
            }
            answer.UserId = userId;

            Console.WriteLine("Answer: " + answer.HTML);
            Console.WriteLine("UserId: " + answer.UserId);
            Console.WriteLine("QuestionId: " + answer.QuestionId);

            _gamesContext.Answers.Add(answer);
            _gamesContext.SaveChanges();
            Console.WriteLine("answer saved");
            return Json(responseModel);
        }
    }
}
