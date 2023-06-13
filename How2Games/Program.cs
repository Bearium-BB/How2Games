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
using How2Games.DataAccess.SearchBarAction;
using How2Games.Services.SearchBarServices;
using Microsoft.AspNetCore.Identity.UI.Services;
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
using How2Games.DataAccess.SearchBarAction;
using How2Games.Domain;

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


            options.UseSqlServer(builder.Configuration.GetConnectionString(@"Data Source=(localdb)\ProjectModels;Initial Catalog=How2Games;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=True")));
            
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

            //builder.Services.AddScoped<ITagCRUD, TagCRUD>();
            //builder.Services.AddScoped<ITagCRUDServices, TagCRUDServices>();

            builder.Services.AddScoped<IGenreTagCRUD, GenreTagCRUD>();
            builder.Services.AddScoped<IGenreTagCRUDServices, GenreTagCRUDServices>();

            builder.Services.AddScoped<IDeveloperTagCRUD, DeveloperTagCRUD>();
            builder.Services.AddScoped<IDeveloperTagCRUDServices, DeveloperTagCRUDServices>();

            builder.Services.AddScoped<IPublisherTagCRUD, PublisherTagCRUD>();
            builder.Services.AddScoped<IPublisherTagCRUDServices, PublisherTagCRUDServices>();

            builder.Services.AddScoped<IGameCRUD, GameCRUD>();
            builder.Services.AddScoped<IGameCRUDServices, GameCRUDServices>();


            builder.Services.AddScoped<ISearchTypes, SearchTypes>();
            builder.Services.AddScoped<ISearchBarServices, SearchBarServices>();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;

                var context = service.GetRequiredService<GamesContext>();

                context.Database.Migrate();

                var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

                // Call the InitializeRoles method
                RoleInitializer.InitializeRoles(roleManager);


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

            _ = RoleInitializer.Initialize(app);
            app.Run();
        }

    }
}