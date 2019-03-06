using DraftCanvas.Models;
using System.Collections.Generic;
using System.Linq;

namespace DraftCanvas.Servicies
{
    internal class PointManager
    {
        internal List<DcPoint> Points = new List<DcPoint>();
        internal List<Constraint> Constraints = new List<Constraint>();

        internal int CreatePoint(double x, double y, int pointIndex, int ownerId)
        {
            Constraint constraint = null;
            for (int i = 0; i < Points.Count; i++)
            {
                if (Points[i].X == x && Points[i].Y == y)
                {
                    constraint = new Constraint(Points[i].ID, "equal");
                    break;
                }
            }
            DcPoint point = new DcPoint(x, y, pointIndex, ownerId);

            if (constraint != null)
            {
                constraint.SetSub(point.ID);
                Constraints.Add(constraint);
            }

            Points.Add(point);

            return (point.ID);
        }

        internal bool HasConstraint(int pointId)
        {
            return Constraints.Where(c => c.SubID == pointId).FirstOrDefault() != null;
        }
    }
}
