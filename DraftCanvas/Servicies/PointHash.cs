using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftCanvas.Servicies
{
    internal static class PointHash
    {
        public static int GetHashCode(int index, int id)
        {
            return (index << 4) + id;
        }
    }
}
