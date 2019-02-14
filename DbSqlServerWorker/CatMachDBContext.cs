using DbSqlServerWorker.Models;
using Microsoft.EntityFrameworkCore;

namespace DbSqlServerWorker
{
    public class CatMachDBContext : DbContext
    {
        public DbSet<CuttingMachine> CuttingMachines { get; set; }
        public DbSet<MaterialGroup> MaterialGroups { get; set; }
        public DbSet<Material> Materials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CNCEstimateDB;Trusted_Connection=True;");
        }
    }
}
