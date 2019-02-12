using DbSqlServerWorker.Models;
using Microsoft.EntityFrameworkCore;

namespace DbSqlServerWorker
{
    public class CatMachDBContext : DbContext
    {
        public DbSet<CuttingMachine> CuttingMachines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CuttingMachineDB;Trusted_Connection=True;");
        }
    }
}
