using KAPITypes;
using Kompas6API5;
using Kompas6Constants;
using KompasNet.Models;

namespace KompasNet.Documents
{
    public class CreateDocument2D
    {
        public void Create(string fileName, MainStamp mainStamp)
        {
            KompasObjectFactory.Open();

            if (KompasObjectFactory.Kompas != null)
            {
                KompasObject Kompas = KompasObjectFactory.Kompas;

                DocumentParam documentParam;
                documentParam = (DocumentParam)Kompas.GetParamStruct((short)StructType2DEnum.ko_DocumentParam);
                documentParam.Init();
                documentParam.type = (short)DocType.lt_DocSheetStandart;
                documentParam.fileName = fileName;

                SheetPar sheetPar;
                sheetPar = (SheetPar)documentParam.GetLayoutParam();
                sheetPar.layoutName = @"C:\Program Files\ASCON\KOMPAS-3D v17\Sys\GRAPHIC.LYT"; 
                sheetPar.shtType = 1;  //Тип документа

                //Подготавливаем параметры листа
                StandartSheet standartSheet;
                standartSheet = (StandartSheet)sheetPar.GetSheetParam();
                standartSheet.direct = false; //надпись вдоль короткой стороны
                standartSheet.format = 4;     //А4
                standartSheet.multiply = 1;   //кратность

                Document2D document2D;
                document2D = (Document2D)Kompas.Document2D();
                document2D.ksCreateDocument(documentParam);

                new CreateStamp().Create(document2D, mainStamp);

                Kompas.Visible = true;
            }
        }

    }
}
