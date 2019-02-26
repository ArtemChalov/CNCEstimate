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
            KManager.Open();

            if (KManager.Kompas != null)
            {
                KompasObject Kompas = KManager.Kompas;
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
            KManager.Open();

            if (KManager.Kompas != null)
            {
                KompasObject Kompas = KManager.Kompas;

                var document2D = (Document2D)Kompas.ActiveDocument2D();

                if (document2D != null) return document2D;
            }
            return null;
        }

        public void GetViewPram()
        {
            KManager.Open();

            if (KManager.Kompas != null)
            {
                KompasObject Kompas = KManager.Kompas;

                IApplication app = Kompas.ksGetApplication7();

                foreach(IKompasDocument item in app.Documents)
                {
                    MessageBox.Show($"Type: {item.DocumentType}\nName: {item.Name}\nActive: {item.Active}");
                }

                return;

                IKompasDocument2D doc = (IKompasDocument2D)app.Documents.AddWithDefaultSettings(DocumentTypeEnum.ksDocumentDrawing);
                if (doc != null)
                {
                    ILayoutSheet layout = doc.LayoutSheets[doc.LayoutSheets.Count - 1];

                    SheetFormat format = layout.Format;
                    format.VerticalOrientation = false;
                    format.Format = ksDocumentFormatEnum.ksFormatA3;
                    layout.Update();

                    IStamp stamp = layout.Stamp;
                    IText text = stamp.Text[1];
                    text.Str = "Part";
                    stamp.Update();

                    ViewsAndLayersManager viewManageer = doc.ViewsAndLayersManager;
                    Views views = viewManageer.Views;
                    IDrawingObject drawingObject = views[views.Count - 1];

                    IView view = (IView)drawingObject;
                    view.Scale = 0.5;
                    view.Update();
                    drawingObject.Update();

                    viewManageer = doc.ViewsAndLayersManager;
                    views = viewManageer.Views;
                    drawingObject = views[views.Count - 1];
                    view = (IView)drawingObject;


                    IDrawingContainer container = (IDrawingContainer)view;

                    ILineSegment lineSegment = container.LineSegments.Add();
                    lineSegment.Style = 1;
                    //lineSegment.Length = 200;
                    lineSegment.X1 = 30;
                    lineSegment.Y1 = 60;
                    lineSegment.X1 = 300;
                    lineSegment.Y1 = 120;
                    //lineSegment.Angle = 30;
                    lineSegment.Update();
                    view.Update();
                    drawingObject.Update();
                }
                else
                    MessageBox.Show("Не получилось создать документ!");
            }
        }

        private bool Create2DDocAPI5(string fileName)
        {
            bool res = false;
            return res;
        }

        private bool Create2DDocAPI7(string fileName)
        {
            bool res = false;
            return res;
        }
    }
}
