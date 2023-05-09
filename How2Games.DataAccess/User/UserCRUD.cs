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
    public class UserCRUD : IUserCRUD // Define the public class UserCRUD that implements the IUserCRUD interface
    {
        // Define private variables for the necessary dependencies
        private readonly GamesContext _context;
        private readonly SignInManager<How2GamesUser> _signInManager;
        private readonly UserManager<How2GamesUser> _userManager;
        private readonly IUserStore<How2GamesUser> _userStore;
        private readonly IUserEmailStore<How2GamesUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly PasswordHasher<IdentityUser> _passwordHasher;

        // Constructor that injects the dependencies
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

        // Method to insert a new user into the database
        public void Insert(string FullName, string Email, string UserName, string Password)
        {
            How2GamesUser user = new How2GamesUser(); // Create a new instance of the How2GamesUser class

            // Set the properties of the user object based on the parameters passed to the method
            user.FullName = FullName;
            user.Email = Email;
            user.UserName = UserName;
            user.EmailConfirmed = true;

            // Hash the user's password using the PasswordHasher class and set it to the user object
            var hashedPassword = _passwordHasher.HashPassword(user, Password);
            user.PasswordHash = hashedPassword;

            // Add the user object to the Users DbSet of the GamesContext and save changes to the database
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
