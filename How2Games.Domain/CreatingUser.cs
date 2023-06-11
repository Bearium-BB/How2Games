
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


namespace How2Games.Domain
{
    public class CreatingUser 
    {
        public How2GamesUser CreateUser(string FullName, string Email, string UserName, string password)
        {
            How2GamesUser user = new How2GamesUser();
            user.FullName = FullName;
            user.Email = Email;
            user.UserName = UserName;
            user.EmailConfirmed = true;
            return user;
        }


    }
}

