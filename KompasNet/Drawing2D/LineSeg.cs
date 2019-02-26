using Kompas6API5;
using KompasAPI7;
using KompasNet.Documents;

namespace KompasNet.Drawing2D
{
    public class LineSeg : DrawPrimitive
    {
        private double _x1;
        private double _y1;
        private double _x2;
        private double _y2;
        private int _style;

        public LineSeg(double x1, double y1, double x2, double y2, int style)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            Style = style;
        }

        public double X1
        {
            get { return _x1; }
            set { _x1 = value; }
        }

        public double Y1
        {
            get { return _y1; }
            set { _y1 = value; }
        }

        public double X2
        {
            get { return _x2; }
            set { _x2 = value; }
        }

        public double Y2
        {
            get { return _y2; }
            set { _y2 = value; }
        }

        public int Style
        {
            get { return _style; }
            set { _style = value; }
        }

        public void Draw()
        {
            IDrawingContainer container = KManager2D.GetIDrawingContainer();

            if (container == null) return;

            ILineSegment lineSegment = container.LineSegments.Add();
            lineSegment.Style = Style;
            lineSegment.X1 = X1;
            lineSegment.Y1 = Y1;
            lineSegment.X2 = X2;
            lineSegment.Y2 = Y2;
            lineSegment.Update();
        }
    }
}
