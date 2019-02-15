using Caliburn.Micro;

namespace Primitives
{
    class LineObj : PropertyChangedBase, IBasePrimitive
    {
        private double _speed;
        private double _length;
        private double _brakeCoeff;

        public LineObj(double speed, double totalLength, double brakeCoeff)
        {
            _speed = speed;
            _length = totalLength;
            _brakeCoeff = brakeCoeff;
        }

        public string Tag { get => "Line"; }

        // Totla length in millimeters
        public double Length
        {
            get { return _length; }
            set
            {
                _length = value;
                NotifyOfPropertyChange(nameof(Time));
            }
        }

        // Coefficient used as multiplier to the edge section length
        public double A
        {
            get { return _brakeCoeff; }
            set
            {
                _brakeCoeff = value;
                NotifyOfPropertyChange(nameof(Time));
            }
        }

        public double B { get; set; } = 1;
        // Cutting speed in millimeter per minute
        // specified with material
        public double Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                NotifyOfPropertyChange(nameof(Time));
            }
        }

        // Edge section length
        public double SLength { get; set; } = 10;

        // Main length
        public double MLength { get => CalcMainLength(); }

        public double Time => SLength * Speed * A + MLength * Speed;

        private double CalcMainLength()
        {
            if (Length - (SLength * 2) > 0)
                return Length - (SLength * 2);

            return 0;
        }
    }
}
