﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.DataAccess.User
{
    public interface IUserCRUD
    {
        void Insert(string FullName, string Email, string UserName, string Password);
    }
}
