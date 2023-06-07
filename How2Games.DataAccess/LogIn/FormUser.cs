using How2Games.Domain.DB;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.DataAccess.LogIn
{
    public class FormUser : IFormUsercs
    {
        private readonly SignInManager<How2GamesUser> _signInManager;
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public bool IsSignUp { get; set; }
        public FormUser(SignInManager<How2GamesUser> signInManager) {
            _signInManager = signInManager;
        }
    }
}
