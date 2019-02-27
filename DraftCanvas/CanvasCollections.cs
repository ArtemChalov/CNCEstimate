using System.Collections.Generic;

namespace DraftCanvas
{
    public static class CanvasCollections
    {
        private static readonly IList<DcPoint> _points = new List<DcPoint>();
        private static int _pointID = -1;
        private static int _primitiveID = -1;

        public static int PointId => ++_pointID;
        public static int PrimitiveID => ++_primitiveID;

        public static IList<DcPoint> Points  => _points;
    }
}
