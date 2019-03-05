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
            double DelataX = 0;
            double DelataY = 0;
            bool res = false;
            switch (pointIndex)
            {
                case 1:
                    DelataX = newX - X1;
                    DelataY = newY - Y1;
                    res = OnP1Changed(newX, newY);
                    if (LocalConstraint != LineConstraint.Free)
                        res = OnP2Changed(X2 + DelataX, Y2 + DelataY);
                    break;
                case 2:
                    DelataX = newX - X2;
                    DelataY = newY - Y2;
                    res = OnP2Changed(newX, newY);
                    if (LocalConstraint != LineConstraint.Free)
                        res = OnP1Changed(X1 + DelataX, Y1 + DelataY);
                    break;
            }
            return res;
        }

        private bool OnP1Changed(double newX, double newY)
        {
            bool res = Resolver.ResolveConstraint(_p1Id, newX, newY);

            _x1 = newX;
            _y1 = newY;

            IsDirty = true;

            return res;
        }

        private bool OnP2Changed(double newX, double newY)
        {
            bool res = Resolver.ResolveConstraint(_p2Id, newX, newY);

            _x2 = newX;
            _y2 = newY;

            IsDirty = true;

            return res;
        }

        private void OnLengthChanged(double newValue)
        {
            double delta = newValue -_length;
            _length = newValue;

            double x1 = X1 - DcMath.Xoffset(delta / 2, Angle);
            double y1 = Y1 - DcMath.Yoffset(delta / 2, Angle);

            OnP1Changed(x1, y1);

            double x2 = X2 + DcMath.Xoffset(delta / 2, Angle);
            double y2 = Y2 + DcMath.Yoffset(delta / 2, Angle);

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
