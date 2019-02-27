
namespace DraftCanvas
{
    public struct DcPoint
    {
        private static int _idCounter = -1;

        public DcPoint(double x, double y)
        {
            ID = ++_idCounter;
            X = x;
            Y = y;
            HConstraint = false;
            VConstraint = false;
        }
        public int ID { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public bool HConstraint { get; set; }
        public bool VConstraint { get; set; }

    }
}
