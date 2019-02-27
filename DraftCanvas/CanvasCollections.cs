using System.Collections.Generic;

namespace DraftCanvas
{
    public static class CanvasCollections
    {
        private static readonly IList<DcPoint> _points = new List<DcPoint>();
        private static int _pointID = -1;

        public static int PointId { get => ++_pointID; }

        public static IList<DcPoint> Points { get => _points; }
    }
}
