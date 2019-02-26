using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DraftCanvas.Primitives
{
    public class DcLineSegment : IVisualizable
    {
        public DcLineSegment(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
        }

        public double X1 { get; set; }
        public double X2 { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }

        public DrawingVisual GetVisual()
        {
            DrawingVisual visual = new DrawingVisual();

            using (DrawingContext drawingContext = visual.RenderOpen())
            {
                drawingContext.DrawLine(new Pen(Brushes.White, 2), new Point(X1, Y1), new Point(X2, Y2));
            }

            return visual;
        }
    }
}
