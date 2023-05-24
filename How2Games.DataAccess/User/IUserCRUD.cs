using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.DataAccess.User
{
    public interface IUserCRUD
    {
        void Insert(string FirstName, string LastName, string Email, string UserName, string password);
    }
}
