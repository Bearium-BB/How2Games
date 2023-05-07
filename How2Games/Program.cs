using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using How2Games.DataAccess.Data;
using How2Games.DataAccess.User;
using How2Games.Domain.DB;
using How2Games.Services.User;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;

namespace How2Games
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddControllersWithViews();

            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<GamesContext>(options =>
            options.UseMySql("server=206.45.156.125;port=3306;database=test;user=brett;",
                new MySqlServerVersion(new Version(8, 0, 26))) // Replace with the appropriate MySQL version you're using
            .EnableSensitiveDataLogging(true)
            .EnableDetailedErrors(true));

            builder.Services.AddDefaultIdentity<How2GamesUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<GamesContext>();
            builder.Services.AddScoped<PasswordHasher<IdentityUser>>();

            builder.Services.AddScoped<IUserCRUD, UserCRUD>();
            builder.Services.AddScoped<IUserCRUDServices, UserCRUDServices>();

            var app = builder.Build();

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