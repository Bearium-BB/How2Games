﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.Services.User
{
    public interface IUserCRUDServices
    {
        Task Insert(string FullName, string Email, string UserName, string password);
    }
}
