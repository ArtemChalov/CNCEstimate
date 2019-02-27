using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

namespace DraftCanvas.Primitives
{
    public class DcLineSegment : IPrimitive, IVisualizable
    {
        private DcPoint _p1;
        private DcPoint _p2;
        private double _length;
        private double _angle;
        private Orientation _lineOrientation;
        private readonly string _tag;
        private readonly int _id;

        #region Constructors

        public DcLineSegment()
        {
            _id = CanvasCollections.PrimitiveID;
            _tag = "LineSegment";
        }

        public DcLineSegment(double x1, double y1, double x2, double y2) : base()
        {
            LineOrientation = Orientation.Free;
           
            _p1 = new DcPoint(x1, y1);
            P2 = new DcPoint(x2, y2);
        }

        public DcLineSegment(DcPoint point1, DcPoint point2) : base()
        {
            LineOrientation = Orientation.Free;

            _p1 = point1;
            P2 = point2;
        }

        public DcLineSegment(DcPoint point1, Orientation orientation, double length) : base()
        {
            if (orientation == Orientation.Free) throw new ArgumentException("LineSegment orientation has value \"Free\"!");

            _p1 = point1;
            _lineOrientation = orientation;
            _length = length;
            if (orientation == Orientation.Horizontal)
            {
                _p2 = new DcPoint(point1.X + length, point1.Y);
                if (length > 0) _angle = 0;
                else _angle = 180;
            }
            if (orientation == Orientation.Vertical)
            {
                _p2 = new DcPoint(point1.X, point1.Y + length);
                if (length > 0) _angle = 90;
                else _angle = 270;
            }
        }

        public DcLineSegment(DcPoint point1, double length, double angel) : base()
        {
            LineOrientation = Orientation.Free;
            _p1 = point1;
            _length = length;
            Angel = angel;
        }

        #endregion

        #region Properties

        public int ID => _id;

        public string Tag => _tag;

        public DcPoint P1
        {
            get { return _p1; }
            set
            {
                _p1 = value;
                OnP1Changed(value);
            }
        }

        public DcPoint P2
        {
            get { return _p2; }
            set
            {
                _p2 = value;
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

        public double Angel
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

        private void OnP2Changed(DcPoint value)
        {

        }

        private void OnLengthChanged(double value)
        {

        }

        private void OnP1Changed(DcPoint value)
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
                drawingContext.DrawLine(new Pen(CanvasParam.PenColor, CanvasParam.Thikness / CanvasParam.Scale), new Point(P1.X, CanvasParam.CanvasHeight - P1.Y), new Point(P2.X, CanvasParam.CanvasHeight - P2.Y));
            }

            visual.Transform = new ScaleTransform(CanvasParam.Scale, CanvasParam.Scale, 0, CanvasParam.CanvasHeight);

            return visual;
        }
    }
}
