using System;
using Caliburn.Micro;

namespace Primitives
{
    public class LineObj : PropertyChangedBase, IBasePrimitive
    {
        private double _length;
        private double _brakeCoefficient;
        private double _normalizedLength;
        private double _edgeLength;

        public LineObj(double length, double brakeCoeff, double edjeLength = 10)
        {
            _length = length;
            _brakeCoefficient = brakeCoeff;
            _edgeLength = edjeLength;
        }

        public string Tag { get => "Line"; }

        // Totla length in millimeters
        public double Length
        {
            get { return _length; }
            set
            {
                _length = value;
                OnCalcNormalizedLength(value);
                NotifyOfPropertyChange();
            }
        }

        public double NormalizedLength {
            get { return _normalizedLength; }
            set
            {
                _normalizedLength = value;
                NotifyOfPropertyChange();
            }
        }

        // Edge section length
        public double EdgeLength
        {
            get { return _edgeLength; }
            set { _edgeLength = value; }
        }

        // Coefficient used as multiplier to the edge section length
        public double BrakeCoefficient
        {
            get { return _brakeCoefficient; }
            set { _brakeCoefficient = value; }
        }

        public double Coeff { get; set; } = 1;

        private void OnCalcNormalizedLength(double length)
        {
            var mainLength = length - EdgeLength;
            if (mainLength < 0) mainLength = 0;

            NormalizedLength = mainLength + EdgeLength / BrakeCoefficient;
        }
    }
}
