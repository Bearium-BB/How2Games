using How2Games.Domain.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How2Games.DataAccess.Data
{
    public class SteamApiContext : DbContext
    {
        public SteamApiContext(DbContextOptions<SteamApiContext> options) : base(options) { }
        public DbSet<SteamGameIdName> SteamGameIdName { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=mysql.brettbowley.com;port=3306;database=test2;user=brett;";
            ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);
            optionsBuilder.UseMySql(connectionString, serverVersion)
                    .EnableSensitiveDataLogging(true)
                    .EnableDetailedErrors(true);
        }
    }
}
