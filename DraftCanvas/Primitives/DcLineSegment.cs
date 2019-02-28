using System.Windows;
using System.Windows.Media;
using PM = DraftCanvas.Servicies.PointManager;

namespace DraftCanvas.Primitives
{
    public class DcLineSegment : IPrimitive, IVisualizable
    {
        private int _point_1_ID = -1;
        private int _point_2_ID = -1;
        private double _length;
        private double _angle;
        private Orientation _lineOrientation;
        private readonly string _tag = "LineSegment";
        private readonly int _id = CanvasCollections.PrimitiveID;

        #region Constructors

        private DcLineSegment() { }

        public DcLineSegment(double x1, double y1, double x2, double y2) : base()
        {
            LineOrientation = Orientation.Free;

            foreach(DcPoint point in PM.Points)
            {
                if (point.X == x1 && point.Y == y1)
                {
                    _point_1_ID = point.ID;
                }
                if (point.X == x2 && point.Y == y2)
                {
                    _point_2_ID = point.ID;
                }
                if (_point_1_ID >= 0 && _point_2_ID >= 0)
                    break;
            }

            if (_point_1_ID == -1)
            {
                DcPoint point = new DcPoint(x1, y1);
                _point_1_ID = point.ID;
            }

            if (_point_2_ID == -1)
            {
                DcPoint point = new DcPoint(x2, y2);
                _point_2_ID = point.ID;
            }
        }

        //public DcLineSegment(DcPoint point1, DcPoint point2) : base()
        //{
        //    LineOrientation = Orientation.Free;

        //    _p1 = point1;
        //    P2 = point2;
        //}

        //public DcLineSegment(DcPoint point1, Orientation orientation, double length) : base()
        //{
        //    if (orientation == Orientation.Free) throw new ArgumentException("LineSegment orientation has value \"Free\"!");

        //    _p1 = point1;
        //    _lineOrientation = orientation;
        //    _length = length;
        //    if (orientation == Orientation.Horizontal)
        //    {
        //        _p2 = new DcPoint(point1.X + length, point1.Y);
        //        if (length > 0) _angle = 0;
        //        else _angle = 180;
        //    }
        //    if (orientation == Orientation.Vertical)
        //    {
        //        _p2 = new DcPoint(point1.X, point1.Y + length);
        //        if (length > 0) _angle = 90;
        //        else _angle = 270;
        //    }
        //}

        //public DcLineSegment(DcPoint point1, double length, double angle) : base()
        //{
        //    LineOrientation = Orientation.Free;
        //    _p1 = point1;
        //    _length = length;
        //    _angle = angle;
        //    _p2 = DcMath.GetLine_P2_ByLengthAndAngel(point1, length, angle);
        //}

        #endregion

        #region Properties

        public int ID => _id;

        public string Tag => _tag;

        public int Point_1_ID
        {
            get { return _point_1_ID; }
            set
            {
                _point_1_ID = value;
                OnP1Changed(value);
            }
        }

        public int Point_2_ID
        {
            get { return _point_2_ID; }
            set
            {
                _point_2_ID = value;
                OnP2Changed(value);
            }
        }

        public double Length
        {
            get { return _length; }
            set { _length = value;
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

        #endregion

        private void OnOrientationChanged(Orientation value)
        {

        }

        private void OnP2Changed(int value)
        {

        }

        private void OnLengthChanged(double value)
        {

        }

        private void OnP1Changed(int value)
        {
            
        }

        private void OnAngelChanged()
        {

        }

        public DrawingVisualEx GetVisual()
        {
            DrawingVisualEx visual = new DrawingVisualEx(this);

            using (DrawingContext drawingContext = visual.RenderOpen())
            {
                drawingContext.DrawLine(new Pen(CanvasParam.PenColor, CanvasParam.Thikness / CanvasParam.Scale),
                    new Point(PM.GetX(Point_1_ID), CanvasParam.CanvasHeight - PM.GetY(Point_1_ID)), new Point(PM.GetX(Point_2_ID), CanvasParam.CanvasHeight - PM.GetY(Point_2_ID)));
            }

            visual.Transform = new ScaleTransform(CanvasParam.Scale, CanvasParam.Scale, 0, CanvasParam.CanvasHeight);

            return visual;
        }
    }
}
