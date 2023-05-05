using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using How2Game.DataAccess.User;

namespace How2Games.Services.User
{
    public class UserCRUDServices : IUserCRUDServices
    {
        private readonly IUserCRUD _userCRUD;

        public UserCRUDServices(IUserCRUD userCRUD)
        {
            _userCRUD = userCRUD;
        }

        public void Insert(string FullName, string Email, string UserName, string password)
        {
            _userCRUD.Insert(FullName, Email, UserName, password);
        }

    }
}
