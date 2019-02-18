using Kompas6API5;
using Kompas6Constants;
using KompasNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KompasNet.Documents
{
    public class CreateStamp
    {
        private MainStamp _stamp;
        public CreateStamp(MainStamp stamp)
        {
            _stamp = stamp;
        }

        public void Create(Document2D document2D, KompasObject Kompas)
        {
            Stamp stamp;
            stamp = document2D.GetStamp();
            stamp.ksOpenStamp();
            foreach (var item in _stamp.SignDict)
            {
                if (item.Value > 0)
                {
                    stamp.ksColumnNumber(item.Value);
                    TextItemParam textItemParam;
                    textItemParam = (TextItemParam)Kompas.GetParamStruct((short)StructType2DEnum.ko_TextItemParam);
                    textItemParam.s = _stamp.ValueDict[item.Key];
                    stamp.ksTextLine(textItemParam);
                }
            }
            stamp.ksCloseStamp();
        }
    }
}
