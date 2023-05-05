using How2Game.DataAccess.Data;
using How2Games.Domain.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Game.DataAccess.User
{
    public class UserCRUD : IUserCRUD
    {
        private readonly GamesContext _context;

        public UserCRUD(GamesContext context)
        {
            _context = context;
        }
        public void Insert() { 
            How2GamesUser user = new How2GamesUser();
            user.UserName = "name";
            user.Password = "password";
            user.Email = "email";
            user.FullName = "name2";
            _context.Add(user);
            _context.SaveChanges();
        }
    }
}
