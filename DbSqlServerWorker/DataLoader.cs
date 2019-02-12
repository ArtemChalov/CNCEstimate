using DbSqlServerWorker.Models;
using System.Collections.Generic;
using System.Linq;

namespace DbSqlServerWorker
{
    public static class DataLoader
    {
        static private readonly CatMachDBContext _context = new CatMachDBContext();

        public static List<CuttingMachine> FetchCuttingMachine()
        {
            return _context.CuttingMachines.ToList(); ;
        }

        public static List<MaterialGroup> FetchMaterialGroups()
        {
            return _context.MaterialGroups.ToList(); ;
        }
    }
}
