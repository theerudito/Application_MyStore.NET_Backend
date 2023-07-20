using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store.Database
{
    public class Application_ContextDB : DbContext
    {
        private string connectionStringSqlite;

        public DbSet<MClients> Client { get; set; }

        public DbSet<MProducts> Product { get; set; }
        public DbSet<MCart> Cart { get; set; }

        public DbSet<MCompany> Company { get; set; }
        public DbSet<MAuth> Auth { get; set; }

        public DbSet<MCode> AppCode { get; set; }
        public DbSet<MBrand> Brands { get; set; }
        public DbSet<MCategory> Categories { get; set; }
        public DbSet<MCity> Cities { get; set; }

        public Application_ContextDB()
        {
            string baseDirectory = AppContext.BaseDirectory;
            //string folder = "C:\\Users\\ewine\\source\\repos\\API-REST\\Store\\Store.Database\\MyDatabase\\";
            string folder = "MyDatabase";
            string database = "Store.db";
            string databaseFilePath = Path.Combine(baseDirectory, folder, database);
            connectionStringSqlite = $"Data Source={databaseFilePath}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionStringSqlite);
            //optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
