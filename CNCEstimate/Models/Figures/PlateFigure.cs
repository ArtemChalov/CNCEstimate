using Caliburn.Micro;
using System;
using System.Collections.Generic;

namespace CNCEstimate.Models.Figures
{
    public class PlateFigure : PropertyChangedBase
    {
        private double _h;
        private double _b;
        private double _h1;
        private double _b1;
        private double _s;

        public PlateFigure() { }

        public PlateFigure(double h, double b, double h1, double b1)
        {
            _h = h;
            _b = b;
            _h1 = h1;
            _b1 = b1;
        }

        public double H
        {
            get { return _h; }
            set
            {
                _h = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(nameof(S));
            }
        }

        public double B
        {
            get { return _b; }
            set
            {
                _b = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(nameof(S));
            }
        }

        public double H1
        {
            get { return _h1; }
            set
            {
                _h1 = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(nameof(S));
            }
        }

        public double B1
        {
            get { return _b1; }
            set
            {
                _b1 = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(nameof(S));
            }
        }

        public double S
        {
            get { return CalcSlantLength(); }
            set
            {
                _s = value;
                NotifyOfPropertyChange();
            }
        }

        private double CalcSlantLength()
        {
            var a = H - H1;
            var b = B - B1;

            _s = Math.Round(Math.Sqrt((a * a) + (b * b)));
            return _s;
        }
    }
}
