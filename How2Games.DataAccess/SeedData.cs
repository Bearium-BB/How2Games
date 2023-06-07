using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using How2Games.DataAccess.Data;
using How2Games.Domain;
using How2Games.Domain.DB;
using How2Games.Domain.Roles;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace How2Games.DataAccess
{
    public class SeedData
    {
       

        public static async Task Initialize(IServiceProvider serviceProvider, string testPw)
        {
            using (var context = new GamesContext(
                serviceProvider.GetRequiredService<DbContextOptions<GamesContext>>()))
            {
                var adminID = await EnsureUser(serviceProvider, testPw, "LiaLee2");
                await EnsureRole(serviceProvider, adminID, Roles.Admin.ToString());


            }


        }
        private static async Task<string> EnsureUser(IServiceProvider serviceProvider, string testPw, string username)
        {
            var userManager = serviceProvider.GetService<Microsoft.AspNetCore.Identity.UserManager<How2GamesUser>>();

            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                user = new How2GamesUser
                {
                    UserName = username,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testPw);
            }
            if(user == null)
            {
                throw new Exception("The password is probably not strong enough!");

            }
            return user.Id;

        }
        private static async Task<Microsoft.AspNetCore.Identity.IdentityResult> EnsureRole(IServiceProvider serviceProvider, string iud, string role)
        {
            var roleManager = serviceProvider.GetService<Microsoft.AspNetCore.Identity.RoleManager<IdentityRole>>();
            if(roleManager == null)
            {
                throw new Exception("RoleManager null");
            }
            Microsoft.AspNetCore.Identity.IdentityResult IR;
            if(!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));

            }
            var userManager = serviceProvider.GetService<Microsoft.AspNetCore.Identity.UserManager<How2GamesUser>>();

            var user = await userManager.FindByIdAsync(iud);
            if (user == null)
            {
                throw new Exception($"Test pw not strong enough");
            }
            IR = await userManager.AddToRoleAsync(user, role);
            return IR;
        }
    }
}
