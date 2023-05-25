using How2Games.DataAccess.Data;
using How2Games.Domain.DB;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.V5.Pages.Account.Internal;
using Azure.Core;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using Microsoft.EntityFrameworkCore;
using How2Games.DataAccess.Data;

namespace How2Games.DataAccess.User
{
    public class UserCRUD : IUserCRUD
    {
        private readonly GamesContext _context;
        private readonly SignInManager<How2GamesUser> _signInManager;
        private readonly UserManager<How2GamesUser> _userManager;
        private readonly IUserStore<How2GamesUser> _userStore;
        private readonly IUserEmailStore<How2GamesUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly PasswordHasher<IdentityUser> _passwordHasher;


        public UserCRUD(
            UserManager<How2GamesUser> userManager,
            IUserStore<How2GamesUser> userStore,
            SignInManager<How2GamesUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            GamesContext context,
            PasswordHasher<IdentityUser> passwordHasher)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = (IUserEmailStore<How2GamesUser>)_userStore;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public async Task Insert(string FullName,string Email ,string UserName,string password) {
            How2GamesUser user = new How2GamesUser();
            user.FullName = FullName;
            user.Email = Email;
            user.UserName = UserName;
            user.EmailConfirmed = true;


            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                Console.WriteLine("test");
            }
            else
            {
                Console.WriteLine("test5");

                // User creation failed
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.Description);
                }
            }

        }

    }
}

