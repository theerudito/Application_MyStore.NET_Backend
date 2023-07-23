using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store.Database
{
    public class Application_ContextDB : DbContext
    {
        public Application_ContextDB(DbContextOptions<Application_ContextDB> options)
            : base(options) { }

        public DbSet<MClients> Client => Set<MClients>();
        public DbSet<MProducts> Product => Set<MProducts>();
        public DbSet<MCart> Cart => Set<MCart>();
        public DbSet<MCompany> Company => Set<MCompany>();
        public DbSet<MAuth> Auth => Set<MAuth>();
        public DbSet<MCode> AppCode => Set<MCode>();
        public DbSet<MBrand> Brands => Set<MBrand>();
        public DbSet<MCategory> Categories => Set<MCategory>();
        public DbSet<MCity> Cities => Set<MCity>();
    }
}
