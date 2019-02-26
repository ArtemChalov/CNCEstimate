using KAPITypes;
using Kompas6API5;
using Kompas6Constants;
using KompasAPI7;
using KompasNet.Dictionaries;
using KompasNet.Models;
using System.Windows;

namespace KompasNet.Documents
{
    public class KManager2D
    {
        public void CreateDocument(string fileName, short format, double scale, bool isHorizontal, MainStamp mainStamp)
        {
            if (KManager.Open())
            {
                IApplication app = KManager.Kompas.ksGetApplication7();

                foreach (IKompasDocument item in app.Documents)
                {
                    if (item.Name == fileName)
                    {
                        OnError($"Чертеж с именем \"{fileName}\" уже создан.");
                        return;
                    }
                }

                KompasObject Kompas = KManager.Kompas;

                DocumentParam documentParam;
                documentParam = (DocumentParam)Kompas.GetParamStruct((short)StructType2DEnum.ko_DocumentParam);
                documentParam.Init(); // Сбрасываем все параметры
                documentParam.type = (short)DocType.lt_DocSheetStandart; // Стандартный черетеж
                documentParam.fileName = fileName;

                SheetPar sheetPar;
                sheetPar = (SheetPar)documentParam.GetLayoutParam();
                sheetPar.layoutName = @"C:\Program Files\ASCON\KOMPAS-3D v17\Sys\GRAPHIC.LYT"; // Библиотека с оформлениями
                sheetPar.shtType = 1;  //Тип документа (в данном случае 1 из GRAPHIC.LYT - первый лист по ГОСТ)

                //Подготавливаем параметры листа
                StandartSheet standartSheet;
                standartSheet = (StandartSheet)sheetPar.GetSheetParam();
                standartSheet.format = format;     //А4
                if (format == 4 && isHorizontal == true)
                    isHorizontal = false;
                standartSheet.direct = isHorizontal;  //надпись вдоль короткой стороны
                standartSheet.multiply = 1;   //кратность

                ViewParam viewParam = Kompas.GetParamStruct((short)StructType2DEnum.ko_ViewParam);
                viewParam.Init();
                viewParam.name = "Вид 1";
                viewParam.scale_ = scale;
                viewParam.x = 0;
                viewParam.y = 0;

                Document2D document2D;
                document2D = (Document2D)Kompas.Document2D();

                if (document2D.ksCreateDocument(documentParam))
                {
                    int viewNumber = 0;
                    document2D?.ksCreateSheetView(viewParam, ref viewNumber);
                    if (mainStamp == null)
                    {
                        mainStamp = new MainStamp(null, null);
                        mainStamp.Scale = new HelpDict().ScaleDictionary[viewParam.scale_];
                    }
                    else
                        mainStamp.Scale = new HelpDict().ScaleDictionary[viewParam.scale_];
                    new CreateStamp().Create(document2D, mainStamp);

                    OnDocument2DCreated(new KDocumentItem(fileName, null, true));
                }
            }
        }

        #region Handlers

        public delegate void NewDoc2DEventHandler(KDocumentItem kDocument);
        public delegate void ErrorMessageHandler(string massage);

        #endregion

        #region Events

        public event NewDoc2DEventHandler OnDocument2DCreated;
        public event ErrorMessageHandler OnError;

        #endregion
    }
}
