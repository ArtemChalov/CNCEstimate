using DraftCanvas.Servicies;
using System;
using System.Windows;
using System.Windows.Media;
using PM = DraftCanvas.Servicies.PointManager;

namespace DraftCanvas.Primitives
{
    public class DcLineSegment : IVisualObject
    {
        private int _point_1_ID = -1;
        private int _point_2_ID = -1;
        private double _length;
        private double _angle;
        private Orientation _lineOrientation;
        private double _x1;
        private double _y1;
        private double _x2;
        private double _y2;
        private readonly string _tag = "LineSegment";
        private readonly int _id = CanvasCollections.PrimitiveID;

        #region Constructors

        private DcLineSegment() { }

        public DcLineSegment(double x1, double y1, double x2, double y2)
        {
            LineOrientation = Orientation.Free;

            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;

            //foreach (DcPoint point in PM.Points)
            //{
            //    if (point.X == x1 && point.Y == y1)
            //    {
            //        _point_1_ID = point.ID;
            //        point.ParentsID.Add(ID);
            //    }
            //    if (point.X == x2 && point.Y == y2)
            //    {
            //        _point_2_ID = point.ID;
            //        point.ParentsID.Add(ID);
            //    }
            //    if (_point_1_ID >= 0 && _point_2_ID >= 0)
            //        break;
            //}

            //if (_point_1_ID == -1)
            //{
            //    DcPoint point = new DcPoint(x1, y1, ID);
            //    _point_1_ID = point.ID;
            //}

            //if (_point_2_ID == -1)
            //{
            //    DcPoint point = new DcPoint(x2, y2, ID);
            //    _point_2_ID = point.ID;
            //}

            _length = DcMath.GetDistance(_x1, _y1, _x2, _y2);
            _angle = DcMath.GetLineSegmentAngle(this);

            PrimitiveManager.Primitives.Add(this);
        }

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

        #endregion

        #region Properties

        public int ID => _id;

        public string Tag => _tag;

        public double X1
        {
            get { return _x1; }
            set { _x1 = value;
                On_X1_Changed();
            }
        }

        public double Y1
        {
            get { return _y1; }
            set { _y1 = value;
                On_Y1_Changed();
            }
        }

        public double X2
        {
            get { return _x2; }
            set { _x2 = value;
                On_X2_Changed();
            }
        }

        public double Y2
        {
            get { return _y2; }
            set { _y2 =  value;
                On_Y2_Changed();
            }
        }

        [Obsolete]
        public int Point_1_ID
        {
            get { return _point_1_ID; }
            set { _point_1_ID = value; }
        }
        [Obsolete]
        public int Point_2_ID
        {
            get { return _point_2_ID; }
            set { _point_2_ID = value; }
        }

        public double Length
        {
            get { return _length; }
            set
            {
                IsDirty = true;
                OnLengthChanged(value);
            }
        }

        public double Angle
        {
            get { return _angle; }
            set { _angle = value;
                OnAngelChanged();
            }
        }

        public Orientation LineOrientation
        {
            get { return _lineOrientation; }
            set
            {
                _lineOrientation = value;
                OnOrientationChanged(value);
            }
        }

        public bool IsDirty { get; set; } = false;

        #endregion

        #region Private Methods

        private void On_X1_Changed()
        {

        }

        private void On_Y1_Changed()
        {

        }

        private void On_X2_Changed()
        {

        }

        private void On_Y2_Changed()
        {

        }

        private double _deltaX1;

        public double DelataX1
        {
            get { return _deltaX1; }
            set { _deltaX1 = value; }
        }

        private double _deltaY1;

        public double DelataY1
        {
            get { return _deltaY1; }
            set { _deltaY1 = value; }
        }

        private double _deltaX2;

        public double DelataX2
        {
            get { return _deltaX2; }
            set { _deltaX2 = value; }
        }

        private double _deltaY2;

        public double DelataY2
        {
            get { return _deltaY2; }
            set { _deltaY2 = value; }
        }

        private void OnLengthChanged(double value)
        {
            double delta = value -_length;
            _length = value;

            double x1 = Math.Round((X1 - delta / 2 * Math.Cos(DcMath.DegreeToRadian(Angle))), 6);
            double y1 = Math.Round((Y1 - delta / 2 * Math.Sin(DcMath.DegreeToRadian(Angle))), 6);

            DelataX1 = x1 - X1;
            DelataY1 = y1 - Y1;

            _x1 = x1;
            _y1 = y1;

            double x2 = Math.Round((X2 + delta / 2 * Math.Cos(DcMath.DegreeToRadian(Angle))), 6);
            double y2 = Math.Round((Y2 + delta / 2 * Math.Sin(DcMath.DegreeToRadian(Angle))), 6);

            DelataX2 = x2 - X2;
            DelataY2 = y2 - Y2;

            _x2 = x2;
            _y2 = y2;

            //PM.SetPointWithLengthAndAngle(Point_1_ID, Point_2_ID, ID, value, Angle);
        }

        private void OnAngelChanged()
        {

        }

        private void OnOrientationChanged(Orientation value)
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
