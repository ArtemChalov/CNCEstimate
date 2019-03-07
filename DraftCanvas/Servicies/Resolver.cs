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

        internal bool ResolveConstraint1(double issuerID, double newX, double newY)
        {
            Constraint constraint = null;

            if (_canvas.PointManager.Constraints.Count > 0)
            {
                foreach (var item in _canvas.PointManager.Constraints)
                {
                    if (item.IssuerID == issuerID)
                    {
                        constraint = item;
                        DcPoint point = _canvas.PointManager.Points.Where(p => p.ID == constraint.SubID).First();
                        IVisualObject visualObject = _canvas.GetDrawingVisualById(point.OwnerID).VisualObject;
                        if (visualObject != null)
                        {
                            if (visualObject is IPrimitive primitive)
                            {
                                primitive.SetPoint(newX, newY, point.PointHash);
                            }
                        }
                    }
                }
            }

            return false;
        }

        internal bool ResolveConstraint(Canvas canvas, int objId, double newX, double newY)
        {
            IVisualObject visualObject = canvas.GetDrawingVisualById(objId).VisualObject;

            if (visualObject is IPrimitive primitive)
            {
                primitive.SetPoint(newX, newY, point.PointHash);
            }

            return false;
        }
    }
}
