using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using How2Games.DataAccess.Data;
using How2Games.DataAccess.User;
using How2Games.Domain.DB;
using How2Games.Services.User;
using How2Games.Services.TagServices;
using How2Games.DataAccess.TagAction;
using How2Games.Services.GameServices;
using How2Games.DataAccess.GameAction;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using How2Games.Domain.Roles;
using Microsoft.AspNetCore.Authorization;
using How2Games.DataAccess;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace How2Games
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddControllersWithViews();

            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<GamesContext>(options =>

            options.UseSqlServer(builder.Configuration.GetConnectionString(@"Data Source=localhost\SQLEXPRESS;Database=How2GamesTest23;Integrated Security=false;User ID=zach;Password=NewPassword1234;TrustServerCertificate=true;")));
            
            builder.Services.AddDbContext<SteamApiContext>(options =>
            options.UseMySql("server=mysql.brettbowley.com;port=3306;database=test;user=brett;",
            new MySqlServerVersion(new Version(8, 0, 26)))
            .EnableSensitiveDataLogging(true)
            .EnableDetailedErrors(true));


            builder.Services.AddDefaultIdentity<How2GamesUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<GamesContext>();
            builder.Services.AddScoped<PasswordHasher<IdentityUser>>();

            builder.Services.AddScoped<IUserCRUD, UserCRUD>();
            builder.Services.AddScoped<IUserCRUDServices, UserCRUDServices>();

            builder.Services.AddScoped<ITagCRUD, TagCRUD>();
            builder.Services.AddScoped<ITagCRUDServices, TagCRUDServices>();

            builder.Services.AddScoped<IGameCRUD, GameCRUD>();
            builder.Services.AddScoped<IGameCRUDServices, GameCRUDServices>();

            
            var app = builder.Build();

            using(var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;

                var context = service.GetRequiredService<GamesContext>();  
                context.Database.Migrate();

                var testUserPw = builder.Configuration.GetValue<string>("SeedUserPw");
                // Obtain a reference to the RoleManager
                var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

                // Call the InitializeRoles method
                RoleInitializer.InitializeRoles(roleManager);


                await SeedData.Initialize(service, testUserPw);
            }
// Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

  
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }

    }
}