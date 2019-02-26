
using System.Collections.Generic;

namespace KompasNet.Models
{
    public class MainStamp
    {
        public Dictionary<string, short> SignDict;
        public Dictionary<string, string> ValueDict;
        private string _creator;
        private string _detailName;
        private string _drawingtId;
        private string _material;
        private string _company;
        private string _scale;

        public MainStamp(string creator, string detailName, string drawingtId, string material,  string company, string scale)
        {
            ValueDict = new Dictionary<string, string>()
            {
                {nameof(Creator), null },
                {nameof(DetailName),null },
                {nameof(DrawingtId), null },
                {nameof(Material), null },
                {nameof(Company), null },
                {nameof(Scale), null }
            };
            SignDict = new Dictionary<string, short>()
            {
                {nameof(Creator), -1 },
                {nameof(DetailName), -1 },
                {nameof(DrawingtId), -1 },
                {nameof(Material), -1 },
                {nameof(Company), -1 },
                {nameof(Scale), -1 }
            };
            Creator = creator;
            DetailName = detailName;
            DrawingtId = drawingtId;
            Material = material;
            Company = company;
            Scale = scale;
        }

        public string Creator
        {
            get { return _creator; }
            set
            {
                _creator = value;
                if (string.IsNullOrEmpty(value))
                {
                    SignDict[nameof(Creator)] = -1;
                }
                else
                {
                    SignDict[nameof(Creator)] = 110;
                    ValueDict[nameof(Creator)] = value;
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
        public string DrawingtId
        {
            get { return _drawingtId; }
            set
            {
                _drawingtId = value;
                if (string.IsNullOrEmpty(value))
                {
                    SignDict[nameof(DrawingtId)] = -1;
                }
                else
                {
                    SignDict[nameof(DrawingtId)] = 2;
                    ValueDict[nameof(DrawingtId)] = value;
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
