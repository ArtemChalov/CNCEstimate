using System;
using PM = DraftCanvas.Servicies.PointManager;

namespace DraftCanvas.Servicies
{
    public static class DcMath
    {
        static public DcPoint GetLine_P2_ByLengthAndAngel(DcPoint point1, double length, double angle)
        {
            double x = Math.Round(Math.Cos((Math.PI / 180) * angle), 3);
            double y = Math.Round(Math.Sin((Math.PI / 180) * angle), 3);

            foreach (DcPoint point in PM.Points)
            {
                if (point.X == x && point.Y == y)
                    return point;
            }

            DcPoint newPoint = new DcPoint(x, y);
            PM.Points.Add(newPoint);

            return newPoint;
        }
    }
}
