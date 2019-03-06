using DraftCanvas.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace DraftCanvas.Servicies
{
    internal class Resolver
    {
        Canvas _canvas;

        public Resolver(Canvas canvas)
        {
            _canvas = canvas;
        }

        internal bool ResolveConstraint(double issuerID, double newX, double newY)
        {
            Constraint constraint = null;

            if (PointManager.Constraints.Count > 0)
            {
                foreach (var item in PointManager.Constraints)
                {
                    if (item.IssuerID == issuerID)
                    {
                        constraint = item;
                        DcPoint point = PointManager.Points.Where(p => p.ID == constraint.SubID).First();
                        IVisualObject visualObject = _canvas.GetDrawingVisualById(point.OwnerID).VisualObject;
                        if (visualObject != null)
                        {
                            if (visualObject is IPrimitive primitive)
                            {
                                primitive.SetPoint(newX, newY, point.PointIndex);
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
