using System;
using System.Windows;
using System.Windows.Media;

namespace DraftCanvas.Primitives
{
    public class DcLineSegment : IVisualizable
    {
        private DcPoint _p1;
        private DcPoint _p2;
        private double _length;
        private double _angle;

        public DcLineSegment(double x1, double y1, double x2, double y2)
        {
            DcPoint point1 = new DcPoint(x1, y1);
            DcPoint point2 = new DcPoint(x2, y2);
            P1 = point1;
            P2 = point2;
        }

        public DcLineSegment(DcPoint point1, DcPoint point2)
        {
            P1 = point1;
            P2 = point2;
        }

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
            DrawingVisualEx visual = new DrawingVisualEx("LineSegment");

            using (DrawingContext drawingContext = visual.RenderOpen())
            {
                drawingContext.DrawLine(new Pen(CanvasParam.PenColor, CanvasParam.Thikness / CanvasParam.Scale), new Point(P1.X, P1.Y), new Point(P2.X, P2.Y));
            }

            visual.Transform = new ScaleTransform(CanvasParam.Scale, CanvasParam.Scale, 0, 0);

            return visual;
        }
    }
}
