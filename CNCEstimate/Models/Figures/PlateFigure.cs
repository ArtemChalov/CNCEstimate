using Caliburn.Micro;
using Primitives;
using System;

namespace CNCEstimate.Models.Figures
{
    public class PlateFigure : PropertyChangedBase
    {
        private LineObj _h;
        private LineObj _b;
        private LineObj _h1;
        private LineObj _b1;
        private LineObj _s;

        public PlateFigure(){}

        public PlateFigure(LineObj h, LineObj b, LineObj h1, LineObj b1)
        {
            _h = h;
            _b = b;
            _h1 = h1;
            _b1 = b1;
            _s = new LineObj(2, 0, 0.5);
        }

        public LineObj H
        {
            get { return _h; }
            set { _h = value; NotifyOfPropertyChange(); }
        }

        public LineObj B
        {
            get { return _b; }
            set { _b = value; NotifyOfPropertyChange(); }
        }

        public LineObj H1
        {
            get { return _h1; }
            set { _h1 = value; NotifyOfPropertyChange(); }
        }

        public LineObj B1
        {
            get { return _b1; }
            set { _b1 = value; NotifyOfPropertyChange();
                NotifyOfPropertyChange(nameof(S));
            }
        }

        public LineObj S
        {
            get { return CalcSlantLength(); }
            set { _s = value; NotifyOfPropertyChange(); }
        }

        private LineObj CalcSlantLength()
        {
            if (_s != null)
            {
                var a = H.Length - H1.Length;
                var b = B.Length - B1.Length;

                _s.Length = Math.Sqrt((a * a) + (b * b));
            }
            return _s;
        }
    }
}
