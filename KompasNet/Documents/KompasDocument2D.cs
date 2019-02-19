using KAPITypes;
using Kompas6API5;
using Kompas6Constants;
using KompasAPI7;
using KompasNet.Models;
using System.Windows;

namespace KompasNet.Documents
{
    public class KompasDocument2D
    {
        public void CreateDocument(string fileName, MainStamp mainStamp)
        {
            KompasObjectFactory.Open();

            if (KompasObjectFactory.Kompas != null)
            {
                KompasObject Kompas = KompasObjectFactory.Kompas;
                Kompas.Visible = true;

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
            }
        }

        public Document2D GetDocument()
        {
            KompasObjectFactory.Open();

            if (KompasObjectFactory.Kompas != null)
            {
                KompasObject Kompas = KompasObjectFactory.Kompas;

                var document2D = (Document2D)Kompas.ActiveDocument2D();

                IApplication app = Kompas.ksGetApplication7();
                IDocuments docs = app.Documents;
                OpenDocumentParam odp = docs.GetOpenDocumentParam();
                for (int i = 0; i < docs.Count; i++)
                {
                    IKompasDocument doc = docs[i];
                    DocumentTypeEnum dte = doc.DocumentType;
                    MessageBox.Show(docs[i].Name);
                }

                //if (document2D != null)
                //{
                //    var refer = document2D.reference;
                //    DocumentParam documentParam;
                //    documentParam = (DocumentParam)Kompas.GetParamStruct((short)StructType2DEnum.ko_DocumentParam);
                //    documentParam.Init();
                //    document2D.ksGetObjParam(refer, documentParam);
                //    MessageBox.Show(documentParam.fileName);
                //}

                if (document2D != null) return document2D;
            }
            return null;
        }
    }
}
