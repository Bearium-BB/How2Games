﻿using How2Games.Domain.Roles;
using Microsoft.AspNetCore.Identity;

namespace How2Games.Domain.DB
{
    public class How2GamesUser : IdentityUser
    {
        public string FullName { get; set; }
        
    }
    
}
