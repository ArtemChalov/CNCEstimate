using System.Collections.Generic;
using System.Linq;

namespace DraftCanvas.Servicies
{
    internal static class PointManager
    {
        private static readonly IList<DcPoint> _points = new List<DcPoint>();

        public static IList<DcPoint> Points => _points;

        public static double GetX(int id)
        {
            return Points.Where(p => p.ID == id).First().X;
        }

        public static double GetY(int id)
        {
            return Points.Where(p => p.ID == id).First().Y;
        }
    }
}
