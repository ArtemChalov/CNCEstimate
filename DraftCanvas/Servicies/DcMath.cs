using DraftCanvas.Primitives;
using System;
using PM = DraftCanvas.Servicies.PointManager;

namespace DraftCanvas.Servicies
{
    public static class DcMath
    {
        static public double GetDistance(int p1_ID, int p2_ID)
        {
            double deltaX = Math.Abs(GetDeltaX(p1_ID, p2_ID));
            double deltaY = Math.Abs(GetDeltaY(p1_ID, p2_ID));

            return Math.Round(Math.Sqrt((deltaX * deltaX + deltaY * deltaY)), 6);
        }

        static public double GetLineSegmentLength(DcLineSegment lineSegment)
        {
            return GetDistance(lineSegment.Point_1_ID, lineSegment.Point_2_ID);
        }

        static public double GetDeltaX(int p1_ID, int p2_ID) => PM.GetX(p2_ID) - PM.GetX(p1_ID);

        static public double GetDeltaY(int p1_ID, int p2_ID) => PM.GetY(p2_ID) - PM.GetY(p1_ID);

    }
}
