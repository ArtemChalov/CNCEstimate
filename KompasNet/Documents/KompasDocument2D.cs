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
                standartSheet.direct = false; //надпись вдоль короткой стороны
                standartSheet.format = 4;     //А4
                standartSheet.multiply = 1;   //кратность

                ViewParam viewParam = Kompas.GetParamStruct((short)StructType2DEnum.ko_ViewParam);
                viewParam.Init();
                viewParam.name = "Вид 1";
                viewParam.scale_ = 0.5;
                viewParam.x = 20;
                viewParam.y = 60;

                Document2D document2D;
                document2D = (Document2D)Kompas.Document2D();

                if (document2D.ksCreateDocument(documentParam))
                {
                    int viewNumber = 0;
                    document2D?.ksCreateSheetView(viewParam, ref viewNumber);
                    new CreateStamp().Create(document2D, mainStamp);

                    MessageBox.Show($"Создан чертеж: \"{fileName}\"\nФормат: А{standartSheet.format}\nВид: {viewParam.name}\nМасштаб {viewParam.scale_}");
                }
            }
        }

        public Document2D GetDocument()
        {
            KompasObjectFactory.Open();

            if (KompasObjectFactory.Kompas != null)
            {
                KompasObject Kompas = KompasObjectFactory.Kompas;

                var document2D = (Document2D)Kompas.ActiveDocument2D();

                if (document2D != null) return document2D;
            }
            return null;
        }

        public void GetViewPram()
        {
            KompasObjectFactory.Open();

            if (KompasObjectFactory.Kompas != null)
            {
                KompasObject Kompas = KompasObjectFactory.Kompas;

                Document2D document2D = Kompas.ActiveDocument2D();

                ViewParam viewParam = Kompas.GetParamStruct((short)StructType2DEnum.ko_ViewParam);
                viewParam.Init();
                viewParam.name = "Вид 1";
                viewParam.scale_ = 0.5;
                viewParam.x = 20;
                viewParam.y = 60;
                int viewNumber = 0;

                document2D?.ksCreateSheetView(viewParam, ref viewNumber);

                MessageBox.Show($"Создан вид \"{viewParam.name}\", с номером {viewNumber}.");


                //IApplication app = Kompas.ksGetApplication7();

                //int viewNumber = 0;

                //KompasAPI7.Documents docs = app.Documents;
                //foreach (IKompasDocument item in docs)
                //{
                //    if (item.DocumentType == DocumentTypeEnum.ksDocumentDrawing)
                //    {
                //        var views = ((IKompasDocument2D)item).ViewsAndLayersManager.Views;
                //        foreach (IView view in views)
                //        {
                //            if (item.Name == "Чертеж1.cdw")
                //            {
                //                viewNumber = view.Number;
                //                views.Add(LtViewType.vt_Standart);
                //                IDrawingObject dr = (IDrawingObject)item;
                //                dr.Update();
                //                MessageBox.Show($"Doc Name{item.Name}, Name {view.Name}, scale {view.Scale}");
                //            }
                //        }
                //    }
                //}
            }

            //KompasObjectFactory.Open();
            ////ViewParam viewParam;

            //if (KompasObjectFactory.Kompas != null)
            //{
            //    KompasObject Kompas = KompasObjectFactory.Kompas;
            //    var document2D = (Document2D)Kompas.ActiveDocument2D();

            //    //document2D.ksGetObjParam

            //    ViewParam viewParam = (ViewParam)Kompas.GetParamStruct((short)StructType2DEnum.ko_ViewParam);
            //    MessageBox.Show(viewParam.GetType().ToString());
            //    MessageBox.Show($"Name: {viewParam.name}, scale: {viewParam.scale_}, x: {viewParam.x}, y: {viewParam.y}");
            //}
        }
    }
}
