using dellirium_hotel_data.Entities;
using dellirium_hotel_infraestructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace dellirium_hotel_data.Context
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;
        public AppDbContext(IConfigurationApp configurationApp)
        {
            _connectionString = configurationApp.GetConnectionString("database_connection");
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Users> Users { get; set; }

    }
}
