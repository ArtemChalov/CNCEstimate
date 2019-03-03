using DraftCanvas.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DraftCanvas.Servicies
{
    internal static class PointManager
    {
        //private static readonly IList<DcPoint> _points = new List<DcPoint>();
        private static readonly Queue<int> _dirtyPoints = new Queue<int>();

        public static List<DcPoint> Points = new List<DcPoint>();
        public static Queue<int> DirtyPoints => _dirtyPoints;

        public static List<Constraint> Constraints = new List<Constraint>();


        public static double GetX(int id)
        {
            return Points.Where(p => p.ID == id).First().X;
        }

        public static double GetY(int id)
        {
            return Points.Where(p => p.ID == id).First().Y;
        }

        public static void SetX(int pointId, double value)
        {
            DcPoint point = Points.Where(p => p.ID == pointId).First();
            int index = Points.IndexOf(point);
            point.X = value;
            Points[index] = point;
            if (!DirtyPoints.Contains(point.ID))
                DirtyPoints.Enqueue(point.ID);
        }

        internal static int CreatePoint(double x, double y, int id)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                if (Points[i].X == x && Points[i].Y == y)
                {
                    Constraints.Add(new Constraint(i, Points.Count, "equal"));
                }
            }

            Points.Add(new DcPoint(x, y, id));

            return (Points.Count - 1);
        }

        public static void SetY(int pointId, double value)
        {
            DcPoint point = Points.Where(p => p.ID == pointId).First();
            int index = Points.IndexOf(point);
            point.Y = value;
            Points[index] = point;
            if (!DirtyPoints.Contains(point.ID))
                DirtyPoints.Enqueue(point.ID);
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
                if (Math.Abs(point.X - x2) < 0.05 && Math.Abs(point.Y - y2) < 0.05)
                {
                    //point.ParentID.Add(parentID);
                    return point.ID;
                }
            }

            DcPoint newPoint = new DcPoint(x2, y2, parentID);

            Points.Add(newPoint);

            return newPoint.ID;
        }

        static public void SetPointWithLengthAndAngle(int startPointID, int currentPointID, int parentID, double length, double angle)
        {
            double x1 = GetX(startPointID);
            double y1 = GetY(startPointID);

            double x2 = Math.Round((x1 + length * Math.Cos(DcMath.DegreeToRadian(angle))), 6);
            double y2 = Math.Round((y1 + length * Math.Sin(DcMath.DegreeToRadian(angle))), 6);

            SetX(currentPointID, x2);
            SetY(currentPointID, y2);
        }
    }
}
