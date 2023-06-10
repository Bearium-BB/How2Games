using How2Games.Domain.DB;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using How2Games.DataAccess.LogIn;

namespace How2Games.Services.LogInService
{
    public class FormUserService : IFormUserService
    {
        private readonly IFormUserService _formUserService;
        public FormUserService(IFormUserService formUserService)
        {
            _formUserService = formUserService;
        }
    }
}
