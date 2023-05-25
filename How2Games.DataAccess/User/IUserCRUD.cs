using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.DataAccess.User
{
    public interface IUserCRUD
    {
        Task Insert(string FirstName, string Email, string UserName, string password);
    }
}
