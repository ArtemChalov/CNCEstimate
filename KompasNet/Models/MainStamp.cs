
using System.Collections.Generic;

namespace KompasNet.Models
{
    public class MainStamp
    {
        public Dictionary<string, short> SignDict;
        public Dictionary<string, string> ValueDict;
        private string _developer;
        private string _detailName;
        private string _drawingtSign;
        private string _material;
        private string _company;
        private string _scale;

        public MainStamp(string developer, string detailName = "Деталь")
        {
            ValueDict = new Dictionary<string, string>()
            {
                {nameof(Developer), null },
                {nameof(DetailName),null },
                {nameof(DrawingtSign), null },
                {nameof(Material), null },
                {nameof(Company), null },
                {nameof(Scale), null }
            };
            SignDict = new Dictionary<string, short>()
            {
                {nameof(Developer), -1 },
                {nameof(DetailName), -1 },
                {nameof(DrawingtSign), -1 },
                {nameof(Material), -1 },
                {nameof(Company), -1 },
                {nameof(Scale), -1 }
            };
            Developer = developer;
            DetailName = detailName;
        }

        public string Developer
        {
            get { return _developer; }
            set
            {
                _developer = value;
                if (string.IsNullOrEmpty(value))
                {
                    SignDict[nameof(Developer)] = -1;
                }
                else
                {
                    SignDict[nameof(Developer)] = 110;
                    ValueDict[nameof(Developer)] = value;
                }
            }
        }
        public string DetailName
        {
            get { return _detailName; }
            set
            {
                _detailName = value;
                if (string.IsNullOrEmpty(value))
                {
                    SignDict[nameof(DetailName)] = -1;
                }
                else
                {
                    SignDict[nameof(DetailName)] = 1;
                    ValueDict[nameof(DetailName)] = value;
                }
            }
        }
        public string DrawingtSign
        {
            get { return _drawingtSign; }
            set
            {
                _drawingtSign = value;
                if (string.IsNullOrEmpty(value))
                {
                    SignDict[nameof(DrawingtSign)] = -1;
                }
                else
                {
                    SignDict[nameof(DrawingtSign)] = 2;
                    ValueDict[nameof(DrawingtSign)] = value;
                }
            }
        }
        public string Material
        {
            get { return _material; }
            set
            {
                _material = value;
                if (string.IsNullOrEmpty(value))
                {
                    SignDict[nameof(Material)] = -1;
                }
                else
                {
                    SignDict[nameof(Material)] = 3;
                    ValueDict[nameof(Material)] = value;
                }
            }
        }
        public string Company
        {
            get { return _company; }
            set
            {
                _company = value;
                if (string.IsNullOrEmpty(value))
                {
                    SignDict[nameof(Company)] = -1;
                }
                else
                {
                    SignDict[nameof(Company)] = 9;
                    ValueDict[nameof(Company)] = value;
                }
            }
        }

        public string Scale
        {
            get { return _scale; }
            set
            {
                _scale = value;
                if (string.IsNullOrEmpty(value))
                {
                    SignDict[nameof(Scale)] = -1;
                }
                else
                {
                    SignDict[nameof(Scale)] = 6;
                    ValueDict[nameof(Scale)] = value;
                }
            }
        }
    }
}
