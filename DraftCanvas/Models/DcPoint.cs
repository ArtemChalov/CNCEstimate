using System.Collections.Generic;
using PM = DraftCanvas.Servicies.PointManager;

namespace DraftCanvas
{
    public struct DcPoint
    {
        private static int _idCounter = -1;

        public DcPoint(double x, double y, int parentId)
        {
            ID = ++_idCounter;
            X = x;
            Y = y;
            ParentsID = new List<int>();
            ParentsID.Add(parentId);
            PM.Points.Add(this);
        }

        public int ID { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public List<int> ParentsID { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is DcPoint other)
                return other.X == this.X && other.Y == this.Y;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return this.ID;
        }
    }
}
