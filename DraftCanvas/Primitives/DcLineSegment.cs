using DraftCanvas.Models;
using DraftCanvas.Servicies;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace DraftCanvas.Primitives
{
    public class DcLineSegment : IPrimitive
    {
        private double _length;
        private double _angle;
        private LineConstraint _constraint;
        private double _x1;
        private double _y1;

        private double _x2;
        private double _y2;
        private int _p1Id;
        private int _p2Id;
        private readonly string _tag = "LineSegment";
        private readonly int _id = CanvasCollections.PrimitiveID;

        #region Constructors

        private DcLineSegment() { }

        public DcLineSegment(double x1, double y1, double x2, double y2)
        {
            _constraint = LineConstraint.Free;

            _x1 = x1;
            _y1 = y1;
            _p1Id = PointManager.CreatePoint(x1, y1, 1, ID);
            _x2 = x2;
            _y2 = y2;
            _p2Id = PointManager.CreatePoint(x2, y2, 2, ID);

            if (x1 == x2) _constraint = LineConstraint.Vertical;
            if (y1 == Y2) _constraint = LineConstraint.Horizontal;

            _length = DcMath.GetDistance(_x1, _y1, _x2, _y2);
            _angle = DcMath.GetLineSegmentAngle(this);
        }

        /**
        //public DcLineSegment(double x1, double y1, double length, double angle, Orientation orientation)
        //{
        //    LineOrientation = orientation;

        //    foreach (DcPoint point in PM.Points)
        //    {
        //        if (point.X == x1 && point.Y == y1)
        //        {
        //            _point_1_ID = point.ID;
        //            point.ParentsID.Add(ID);
        //            break;
        //        }
        //    }

        //    if (_point_1_ID == -1)
        //    {
        //        DcPoint point = new DcPoint(x1, y1, ID);
        //        _point_1_ID = point.ID;
        //    }

        //    _point_2_ID = PM.Create_P2_WithLengthAndAngle(_point_1_ID, ID, length, angle);

        //    _angle = angle;
        //    _length = length;

        //    PrimitiveManager.Primitives.Add(this);
        //}
        **/

        #endregion

        #region Properties

        public int ID => _id;

        public string Tag => _tag;

        public double X1
        {
            get { return _x1; }
        }

        public double Y1
        {
            get { return _y1; }
        }

        public double X2
        {
            get { return _x2; }
        }

        public double Y2
        {
            get { return _y2; }
        }

        public double DelataX { get; private set; }

        public double DelataY { get; private set; }

        public double Length
        {
            get { return _length; }
            set {OnLengthChanged(value); }
        }

        public double Angle
        {
            get { return _angle; }
            set { _angle = value;
                OnAngelChanged();
            }
        }

        public LineConstraint LocalConstraint
        {
            get { return _constraint; }
            set
            {
                _constraint = value;
                OnGlobConstrChanged(value);
            }
        }

        public bool IsDirty { get; set; } = false;

        #endregion

        #region Private Methods

        public bool SetPoint(double newX, double newY, int pointIndex)
        {
            switch (pointIndex)
            {
                case 1: return OnP1Changed(newX, newY);
                case 2: return OnP2Changed(newX, newY);
            }
            return false;
        }

        private bool OnP1Changed(double newX, double newY)
        {
            Constraint constraint = null;

            if (PointManager.Constraints.Count > 0)
            {
                foreach (var item in PointManager.Constraints)
                {
                    if (item.IssuerID == _p1Id)
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
                foreach (DrawingVisualEx item in Resolver._visualsCollection)
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

            _x1 = newX;
            _y1 = newY;

            IsDirty = true;

            return true;
        }

        private bool OnP2Changed(double newX, double newY)
        {
            Constraint constraint = null;

            if (PointManager.Constraints.Count > 0)
            {
                foreach (var item in PointManager.Constraints)
                {
                    if (item.IssuerID == _p1Id)
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
                foreach (DrawingVisualEx item in Resolver._visualsCollection)
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

            _x2 = newX;
            _y2 = newY;

            IsDirty = true;

            return true;
        }

        private void OnLengthChanged(double newValue)
        {
            double delta = newValue -_length;
            _length = newValue;

            double x1 = Math.Round((X1 - delta / 2 * Math.Cos(DcMath.DegreeToRadian(Angle))), 6);
            double y1 = Math.Round((Y1 - delta / 2 * Math.Sin(DcMath.DegreeToRadian(Angle))), 6);

            OnP1Changed(x1, y1);

            double x2 = Math.Round((X2 + delta / 2 * Math.Cos(DcMath.DegreeToRadian(Angle))), 6);
            double y2 = Math.Round((Y2 + delta / 2 * Math.Sin(DcMath.DegreeToRadian(Angle))), 6);

            OnP2Changed(x2, y2);
        }

        private void OnAngelChanged()
        {

        }

        private void OnGlobConstrChanged(LineConstraint value)
        {

        }

        #endregion

        public DrawingVisualEx GetVisual()
        {
            DrawingVisualEx visual = new DrawingVisualEx(this);

            using (DrawingContext drawingContext = visual.RenderOpen())
            {
                drawingContext.DrawLine(new Pen(CanvasParam.PenColor, CanvasParam.Thikness / CanvasParam.Scale),
                    new Point(X1, CanvasParam.CanvasHeight - Y1), new Point(X2, CanvasParam.CanvasHeight - Y2));
            }

            visual.Transform = new ScaleTransform(CanvasParam.Scale, CanvasParam.Scale, 0, CanvasParam.CanvasHeight);

            return visual;
        }
    }
}
