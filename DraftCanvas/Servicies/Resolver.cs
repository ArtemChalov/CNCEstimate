using DraftCanvas.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace DraftCanvas.Servicies
{
    static class Resolver
    {
        public static List<Visual> _visualsCollection;

        internal static bool ResolveConstraint(double issuerID, double newX, double newY)
        {
            Constraint constraint = null;

            if (PointManager.Constraints.Count > 0)
            {
                foreach (var item in PointManager.Constraints)
                {
                    if (item.IssuerID == issuerID)
                    {
                        constraint = item;
                        break;
                    }
                }
            }

            if (constraint != null)
            {
                IVisualObject visualObject = null;
                DcPoint point = PointManager.Points.Where(p => p.ID == constraint.SubID).First();
                foreach (DrawingVisualEx item in _visualsCollection)
                {
                    if (item.ID == point.OwnerID)
                    {
                        visualObject = item.VisualObject;
                        break;
                    }
                }

                if (visualObject != null)
                {
                    if (visualObject is IPrimitive primitive)
                    {
                        primitive.SetPoint(newX, newY, point.PointIndex);
                    }
                }
            }
            return false;
        }
    }
}
