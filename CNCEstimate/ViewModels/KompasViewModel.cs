using Caliburn.Micro;
using CNCEstimate.Dialogs;
using KompasNet;
using KompasNet.Documents;
using KompasNet.Drawing2D;
using KompasNet.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace CNCEstimate.ViewModels
{
    public class KompasViewModel : PropertyChangedBase
    {
        private List<KDocumentItem> _kDrawings;
        private KDocumentItem _selectedKDrawing;

        public List<KDocumentItem> KDrawings
        {
            get { return _kDrawings; }
            set { _kDrawings = value;
                NotifyOfPropertyChange(nameof(KDrawings));
            }
        }


        public KDocumentItem SelectedKDrawing
        {
            get { return _selectedKDrawing; }
            set
            {
                _selectedKDrawing = value;
                if (_selectedKDrawing != null)
                {
                    if (!KManager.SetActiveDocument(_selectedKDrawing))
                    {
                        MessageBox.Show($"Чертеж \"{_selectedKDrawing.Name}\"\nбыл закрыт или удален!");
                        KDrawings = KManager.GetDocumentsNameList();
                        _selectedKDrawing = KDrawings.Where(kd => kd.Active == true).FirstOrDefault();
                        NotifyOfPropertyChange(nameof(SelectedKDrawing));
                    }
                }

            }
        }


        public void Open()
        {
            KManager.Open();
            KDrawings = KManager.GetDocumentsNameList();
            _selectedKDrawing = KDrawings.Where(kd => kd.Active == true).FirstOrDefault();
            NotifyOfPropertyChange(nameof(SelectedKDrawing));
        }

        public void Close()
        {
            KManager.Close();
        }

        public void Create2D()
        {
            KManager2D kManager2D = new KManager2D();

            var title = new TitleClass();
            title.Title = "Новый чертеж";
            var window = new InputDataDialogWindow(title);
            window.Title = "Название файла";
            window.Owner = AppStore.MainWindow;

            if(window.ShowDialog() == true)
            {
                kManager2D.OnDocument2DCreated += KManager2D_OnDocument2DCreated;
                kManager2D.CreateDocument(title.Title, 3, 0.5, true, new MainStamp("Чалов", "Косынка", "03.019.001", "Сталь 3", "ООО\n\"АгроПермьКомплекс\"", null));
            }
            title = null;
            kManager2D.OnDocument2DCreated -= KManager2D_OnDocument2DCreated;
            kManager2D = null;
        }

        private void KManager2D_OnDocument2DCreated(KDocumentItem kDocument)
        {
            MessageBox.Show($"Cоздан чертеж \"{kDocument.Name}\"");
        }

        public void DrawLineSeg()
        {
            LineSeg lineSeg = new LineSeg(25, 30, 120, 50, 0);
            lineSeg.Draw();
        }

        public void GetViewParam()
        {
            new KompasDocument2D().GetViewPram();
        }

        internal class TitleClass
        {
            [DisplayName("Название файла")]
            public string Title { get; set; }
        }
    }
}
