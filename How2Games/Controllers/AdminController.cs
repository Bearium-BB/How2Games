using How2Games.DataAccess.Data;
using How2Games.Domain.Roles;
using How2Games.Domain.DB;
using How2Games.Domain.ViewModels;
using How2Games.Services.GameServices;
using How2Games.Services.TagServices;
using How2Games.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace How2Games.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserCRUDServices _userCRUDServices;
        private readonly IGameCRUDServices _gameCRUDServices;
        private readonly UserManager<How2GamesUser> _userManager;
        private readonly SignInManager<How2GamesUser> _signInManager;
        private readonly GamesContext _gamesContext;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AdminController(ILogger<UserController> logger, IUserCRUDServices userCRUDServices, UserManager<How2GamesUser> userManager, SignInManager<How2GamesUser> signInManager, GamesContext gamesContext, RoleManager<IdentityRole> roleManager)

        {
            _logger = logger;
            _userCRUDServices = userCRUDServices;
            _userManager = userManager;
            _signInManager = signInManager;
            _gamesContext = gamesContext;
            _roleManager = roleManager;


        }

        public async Task<IActionResult> Index()
        {


            var users = await _gamesContext.Users.ToListAsync();

            return View(users);
        }

        public async Task<IActionResult> EditUser(string userId)
        {
            string connectionString = "Server =(localdb)\\ProjectModels; Database=How2Games;Integrated Security=True;Connect Timeout=1200;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; MultipleActiveResultSets=True;";
            using (var connection = new SqlConnection(connectionString))
            {

                await connection.OpenAsync();


                using (var getUserCommand = new SqlCommand("SELECT * FROM AspNetUsers WHERE Id = @UserId", connection))
                {
                    getUserCommand.Parameters.AddWithValue("@UserId", userId);


                    using (var reader = await getUserCommand.ExecuteReaderAsync())
                    {




                        await reader.CloseAsync();
                    }
                }


                using (var checkRoleCommand = new SqlCommand("SELECT * FROM AspNetUserRoles WHERE UserId = @UserId", connection))
                {
                    checkRoleCommand.Parameters.AddWithValue("@UserId", userId);


                    using (var reader = await checkRoleCommand.ExecuteReaderAsync())
                    {




                        await reader.CloseAsync();
                    }
                }



            }
            ManageUserRolesViewModel model = new ManageUserRolesViewModel();
            model.user = await _userManager.FindByIdAsync(userId);

            if (model.user == null)
            {
                return View("NotFound");

            }
            foreach (var role in _roleManager.Roles)
            {
                model.RoleId = role.Id;
                model.RoleName = role.Name;


                if (await _userManager.IsInRoleAsync(model.user, role.Name))
                {
                    model.Selected = true;
                }
                else
                {
                    model.Selected = false;
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(string userid, ManageUserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(userid);
            var role = await _userManager.GetRolesAsync(user);
            if (!role.IsNullOrEmpty())
            {
                await _userManager.RemoveFromRoleAsync(user, role.First().ToString());
            }
            model.user = user;
               await _userManager.AddToRoleAsync(user, model.RoleName);
     
            
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
       public IActionResult QuestionsDeleter()
        {
            return View();
        }
        public IActionResult AdminMenu()
        {
            return View();
        }

    }
}
