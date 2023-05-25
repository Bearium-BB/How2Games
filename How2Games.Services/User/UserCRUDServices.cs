using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using How2Games.DataAccess.User;

namespace How2Games.Services.User
{
    public class UserCRUDServices : IUserCRUDServices
    {
        private readonly IUserCRUD _userCRUD;

        public UserCRUDServices(IUserCRUD userCRUD)
        {
            _userCRUD = userCRUD;
        }

        public async Task Insert(string FirstName, string Email, string UserName, string password)
        {
           await _userCRUD.Insert(FirstName, Email, UserName, password);
        }

    }
}
