using DraftCanvas.Primitives;
using System;
using PM = DraftCanvas.Servicies.PointManager;

namespace DraftCanvas.Servicies
{
    public static class DcMath
    {
        [Obsolete]
        static public double GetDistance(int p1_ID, int p2_ID)
        {
            double deltaX = Math.Abs(GetRDeltaX(p1_ID, p2_ID));
            double deltaY = Math.Abs(GetRDeltaY(p1_ID, p2_ID));

            return Math.Round(Math.Sqrt((deltaX * deltaX + deltaY * deltaY)), 6);
        }

        static public double GetDistance(double x1, double y1, double x2, double y2)
        {
            double deltaX = Math.Abs(x2 - x1);
            double deltaY = Math.Abs(y2 - y1);

            return Math.Round(Math.Sqrt((deltaX * deltaX + deltaY * deltaY)), 6);
        }

        [Obsolete]
        static public double GetLineSegmentLength(DcLineSegment lineSegment)
        {
            return GetDistance(lineSegment.Point_1_ID, lineSegment.Point_2_ID);
        }

        static public double GetLineSegmentAngle(DcLineSegment lineSegment)
        {
            //double deltaX = GetRDeltaX(lineSegment.Point_1_ID, lineSegment.Point_2_ID);
            //double deltaY = GetRDeltaY(lineSegment.Point_1_ID, lineSegment.Point_2_ID);

            double deltaX = lineSegment.X2 - lineSegment.X1;
            double deltaY = lineSegment.Y2 - lineSegment.Y1;

            double angle = Math.Round(RadianToDegree(Math.Atan(deltaY / deltaX)), 6);

            if (deltaX < 0)
                angle += 180;

            return angle < 0 ? angle + 360 : angle;
        }


        [Obsolete]
        static public double GetRDeltaX(int p1_ID, int p2_ID) => PM.GetX(p2_ID) - PM.GetX(p1_ID);
        [Obsolete]
        static public double GetRDeltaY(int p1_ID, int p2_ID) => PM.GetY(p2_ID) - PM.GetY(p1_ID);

        //static public double GetDeltaX(int x1, int x2) => PM.GetX(p2_ID) - PM.GetX(p1_ID);

        //static public double GetDeltaY(int p1_ID, int p2_ID) => PM.GetY(p2_ID) - PM.GetY(p1_ID);

        static public double DegreeToRadian(double degree) => Math.PI * degree / 180;

        static public double RadianToDegree(double radian) => radian * 180 / Math.PI;
    }
}
