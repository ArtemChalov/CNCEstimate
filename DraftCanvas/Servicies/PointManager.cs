using System;
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

        /// <summary>
        /// Create new DcPoint
        /// </summary>
        /// <param name="p1ID"></param>
        /// <param name="parentID"></param>
        /// <param name="length"></param>
        /// <param name="angle"></param>
        /// <returns>Returns point ID</returns>
        static public int Create_P2_WithLengthAndAngle(int p1ID, int parentID, double length, double angle)
        {
            double x1 = GetX(p1ID);
            double y1 = GetY(p1ID);

            double x2 = Math.Round((x1 + length * Math.Cos(DcMath.DegreeToRadian(angle))), 6);
            double y2 = Math.Round((y1 + length * Math.Sin(DcMath.DegreeToRadian(angle))), 6);

            foreach (DcPoint point in Points)
            {
                if (Math.Abs(point.X - x2) < 0.01 && Math.Abs(point.Y - y2) < 0.01)
                    return point.ID;
            }

            DcPoint newPoint = new DcPoint(x2, y2, parentID);

            Points.Add(newPoint);

            return newPoint.ID;
        }
    }
}
