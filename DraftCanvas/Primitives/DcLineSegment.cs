using DraftCanvas.Servicies;
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
        private readonly string _tag = "LineSegment";
        private readonly int _id = CanvasCollections.PrimitiveID;

        #region Constructors

        private DcLineSegment() { }

        public DcLineSegment(double x1, double y1, double x2, double y2)
        {
            LineOrientation = Orientation.Free;

            foreach(DcPoint point in PM.Points)
            {
                if (point.X == x1 && point.Y == y1)
                {
                    _point_1_ID = point.ID;
                    point.ParentsID.Add(ID);
                }
                if (point.X == x2 && point.Y == y2)
                {
                    _point_2_ID = point.ID;
                    point.ParentsID.Add(ID);
                }
                if (_point_1_ID >= 0 && _point_2_ID >= 0)
                    break;
            }

            if (_point_1_ID == -1)
            {
                DcPoint point = new DcPoint(x1, y1, ID);
                _point_1_ID = point.ID;
            }

            if (_point_2_ID == -1)
            {
                DcPoint point = new DcPoint(x2, y2, ID);
                _point_2_ID = point.ID;
            }

            _length = DcMath.GetDistance(_point_1_ID, _point_2_ID);
            _angle = DcMath.GetLineSegmentAngle(this);

            PrimitiveManager.Primitives.Add(this);
        }

        public DcLineSegment(double x1, double y1, double length, double angle, Orientation orientation)
        {
            LineOrientation = orientation;

            foreach (DcPoint point in PM.Points)
            {
                if (point.X == x1 && point.Y == y1)
                {
                    _point_1_ID = point.ID;
                    point.ParentsID.Add(ID);
                    break;
                }
            }

            if (_point_1_ID == -1)
            {
                DcPoint point = new DcPoint(x1, y1, ID);
                _point_1_ID = point.ID;
            }

            _point_2_ID = PM.Create_P2_WithLengthAndAngle(_point_1_ID, ID, length, angle);

            _angle = angle;
            _length = length;

            PrimitiveManager.Primitives.Add(this);
        }

        #endregion

        #region Properties

        public int ID => _id;

        public string Tag => _tag;

        public double X1
        {
            get { return PM.GetX(Point_1_ID); }
            set { PM.SetX(Point_1_ID, value);
                On_X1_Changed();
            }
        }

        public double Y1
        {
            get { return PM.GetY(Point_1_ID); }
            set { PM.SetY(Point_1_ID, value);
                On_Y1_Changed();
            }
        }

        public double X2
        {
            get { return PM.GetX(Point_2_ID); }
            set { PM.SetX(Point_2_ID, value);
                On_X2_Changed();
            }
        }

        public double Y2
        {
            get { return PM.GetY(Point_2_ID); }
            set { PM.SetY(Point_2_ID, value);
                On_Y2_Changed();
            }
        }

        public int Point_1_ID
        {
            get { return _point_1_ID; }
            set { _point_1_ID = value; }
        }

        public int Point_2_ID
        {
            get { return _point_2_ID; }
            set { _point_2_ID = value; }
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

        private void OnLengthChanged(double value)
        {
            PM.SetPointWithLengthAndAngle(Point_1_ID, Point_2_ID, ID, value, Angle);
            IsDirty = true;
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
                    new Point(PM.GetX(Point_1_ID), CanvasParam.CanvasHeight - PM.GetY(Point_1_ID)), new Point(PM.GetX(Point_2_ID), CanvasParam.CanvasHeight - PM.GetY(Point_2_ID)));
            }

            visual.Transform = new ScaleTransform(CanvasParam.Scale, CanvasParam.Scale, 0, CanvasParam.CanvasHeight);

            return visual;
        }
    }
}
