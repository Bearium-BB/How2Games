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

        // Define a DbSet for SteamGameIdName entities
        public DbSet<SteamGameIdName> SteamGameIdName { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Set the connection string and database provider
            string connectionString = "server=mysql.brettbowley.com;port=3306;database=test2;user=brett;";
            ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);

            // Configure the DbContext to use MySQL database with the specified connection string
            optionsBuilder.UseMySql(connectionString, serverVersion)
                .EnableSensitiveDataLogging(true)   // Enable sensitive data logging for detailed error messages
                .EnableDetailedErrors(true);        // Enable detailed error messages

            // Note: The connection string and provider configuration should be adjusted as per your specific setup
        }
    }
}
