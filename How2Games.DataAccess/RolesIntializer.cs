using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace How2Games.DataAccess {
    public static class RoleInitializer
    {
        public static void InitializeRoles(RoleManager<IdentityRole> roleManager)
        {
            // Check if the "Admin" role exists
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                // Create the "Admin" role
                var adminRole = new IdentityRole("Admin");
                var result = roleManager.CreateAsync(adminRole).Result;

                // Handle the result if necessary
            }
            if (!roleManager.RoleExistsAsync("Basic").Result)
            {
                // Create the "Admin" role
                var adminRole = new IdentityRole("Basic");
                var result = roleManager.CreateAsync(adminRole).Result;

                // Handle the result if necessary
            }
            if (!roleManager.RoleExistsAsync("BlackList").Result)
            {
                // Create the "Admin" role
                var adminRole = new IdentityRole("Admin");
                var result = roleManager.CreateAsync(adminRole).Result;

                // Handle the result if necessary
            }
        }
    }
}

