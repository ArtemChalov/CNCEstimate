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
                    if (!KompasObjectFactory.SetActiveDocument(_selectedKDrawing))
                    {
                        MessageBox.Show($"Чертеж \"{_selectedKDrawing.Name}\"\nбыл закрыт или удален!");
                        KDrawings = KompasObjectFactory.GetDocumentsNameList();
                        _selectedKDrawing = KDrawings.Where(kd => kd.Active == true).FirstOrDefault();
                        NotifyOfPropertyChange(nameof(SelectedKDrawing));
                    }
                }

            }
        }


        public void Open()
        {
            KompasObjectFactory.Open();
            KDrawings = KompasObjectFactory.GetDocumentsNameList();
            _selectedKDrawing = KDrawings.Where(kd => kd.Active == true).FirstOrDefault();
            NotifyOfPropertyChange(nameof(SelectedKDrawing));
        }

        public void Close()
        {
            KompasObjectFactory.Close();
        }

        public void Create2D()
        {
            var title = new TitleClass();
            title.Title = "Новый чертеж";
            var window = new InputDataDialogWindow(title);
            window.Title = "Название файла";
            window.Owner = AppStore.MainWindow;

            if(window.ShowDialog() == true)
            {
                new KompasDocument2D().CreateDocument(title.Title, null);
            }
            title = null;
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
