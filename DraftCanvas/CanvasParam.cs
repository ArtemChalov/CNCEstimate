using System.Windows.Media;

namespace DraftCanvas
{
    static class CanvasParam
    {
        static internal int Index { get; set; } = -1;

        static public double Thikness { get; set; } = 1.5;

        static public double Scale { get; set; } = 1;

        static public Brush PenColor { get; set; } = Brushes.White;
    }
}
