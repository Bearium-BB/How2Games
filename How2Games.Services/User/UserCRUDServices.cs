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

        public void Insert(string FirstName, string LastName, string Email, string UserName, string password)
        {
            _userCRUD.Insert(FirstName, LastName, Email, UserName, password);
        }

    }
}
