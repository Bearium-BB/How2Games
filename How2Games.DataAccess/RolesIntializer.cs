using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using How2Games.DataAccess.Data;
using How2Games.Domain.DB;
using How2Games.Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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
                // Create the "Basic" role
                var adminRole = new IdentityRole("Basic");
                var result = roleManager.CreateAsync(adminRole).Result;

                // Handle the result if necessary
            }
            if (!roleManager.RoleExistsAsync("BlackList").Result)
            {
                // Create the "BlackListed" role
                var adminRole = new IdentityRole("BlackListed");
                var result = roleManager.CreateAsync(adminRole).Result;

                // Handle the result if necessary
            }
        }
        public static async Task Initialize(IApplicationBuilder applicationBuilder)
        {
            using ( var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<GamesContext>();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<How2GamesUser>>();

                Microsoft.AspNetCore.Identity.IdentityResult IR;
                if (context.Users.Any() != null)
                {
                    var users = new List<FormUser>()
                    {

                        new FormUser
                        {
                            Id = "b6ac3d84-d8a8-4628-a254-be921b4b5630",
                            FirstName = "Lia",
                            LastName = "Lee",
                            Email = "abc@gmail.com",
                            UserName ="LiaLee",
                            Password = "Password1234!",

                        },
                         new FormUser
                        {
                            Id = "b7ac3d84-d8a8-4628-a254-be921b4b5630",
                            FirstName = "Hans",
                            LastName = "KirbyLord",
                            Email = "abc1@gmail.com",
                            UserName ="HansKirbyLord",
                            Password = "Password1234!",

                        },
                          new FormUser
                        {

                            Id = "b8ac3d84-d8a8-4628-a254-be921b4b5630",
                            FirstName = "Zack",
                            LastName = "Zed",
                            Email = "abc2@gmail.com",
                            UserName ="ZacZad",
                            Password = "Password1234!",

                        },
                           new FormUser
                        {

                            Id = "b9ac3d84-d8a8-4628-a254-be921b4b5630",
                            FirstName = "Brett",
                            LastName = "Bowley",
                            Email = "abc3@gmail.com",
                            UserName ="BrettBowleyDotCom",
                            Password = "Password1234!",
                        },

                    };
                    foreach (var user in users) 
                    {
                        var newUser = new How2GamesUser
                        {
                            Id = user.Id,
                            FullName = user.FirstName + user.LastName,
                            Email = user.Email,
                            UserName = user.UserName,

                        };
                        IR = await userManager.CreateAsync(newUser, user.Password);

                        if (IR.Succeeded)
                        {
                            if (user.UserName == "ZacZad")
                            {
                                IR = await userManager.AddToRoleAsync(newUser, "Admin");
                            }
                        }
                
                    }

                }

                 await context.SaveChangesAsync();


            }
        }
    }
}

