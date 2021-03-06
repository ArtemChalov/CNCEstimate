﻿using DbSqlServerWorker.Models;
using System.Collections.Generic;
using System.Linq;

namespace DbSqlServerWorker.DataLoaders
{
    public static class MaterialLoader
    {
        static private readonly CatMachDBContext _context = new CatMachDBContext();

        public static List<MaterialGroup> FetchMaterialGroupsByParent(string parent = null)
        {
            var query = from groups in _context.MaterialGroups
                        orderby groups.MaterialGroupId
                        where groups.Parent == parent
                        select groups;
            return query.ToList();
        }

        public static MaterialGroup FetchMaterialGroupsByGroupId(int groupId)
        {
            var query = from groups in _context.MaterialGroups
                        orderby groups.MaterialGroupId
                        where groups.MaterialGroupId == groupId
                        select groups;
            return query.FirstOrDefault();
        }

        public static List<Material> FetchMaterialsByGroupId(int groupId)
        {
            var query = from materials in _context.Materials
                        orderby materials.MaterialId
                        where materials.MaterialGroupId == groupId
                        select materials;
            return query.ToList();
        }

        public static List<MaterialGroup> FetchMaterialGroups()
        {
            return _context.MaterialGroups.ToList(); ;
        }

        public static string FetchMaterialGostByMaterialGroupId(int groupId)
        {
            var query = from groups in _context.MaterialGroups
                        where groups.MaterialGroupId == groupId
                        select groups.Gost;
            return query.FirstOrDefault();
        }
    }
}
