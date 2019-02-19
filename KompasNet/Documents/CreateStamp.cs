using Kompas6API5;
using Kompas6Constants;
using KompasNet.Models;

namespace KompasNet.Documents
{
    public class CreateStamp
    {
        public void Create(Document2D document2D, MainStamp stamp)
        {
            KompasObject Kompas = KompasObjectFactory.Kompas;
            if (stamp != null && Kompas != null)
            {
                Stamp kstamp = null;
                kstamp = document2D?.GetStamp();
                if (kstamp != null)
                {
                    kstamp.ksOpenStamp();
                    foreach (var item in stamp.SignDict)
                    {
                        if (item.Value > 0)
                        {
                            kstamp.ksColumnNumber(item.Value);
                            TextItemParam textItemParam;
                            textItemParam = (TextItemParam)Kompas.GetParamStruct((short)StructType2DEnum.ko_TextItemParam);
                            textItemParam.s = stamp.ValueDict[item.Key];
                            kstamp.ksTextLine(textItemParam);
                        }
                    }
                    kstamp.ksCloseStamp();
                }
            }
        }
    }
}
