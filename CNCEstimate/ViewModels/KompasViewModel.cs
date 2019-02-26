﻿using Caliburn.Micro;
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

        #region Properties

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

        #endregion

        #region Button Methods

        public void Open()
        {
            KManager.Open();
            GetOpendKDocumentList();
        }

        public void Close()
        {
            KManager.Close();
        }

        public void Create2D()
        {
            KManager2D kManager2D = new KManager2D();

            var title = new TitleClass() { Title = "Новый чертеж" };

            var window = new InputDataDialogWindow(title);
            window.Title = "Название файла";
            window.Owner = AppStore.MainWindow;

            if(window.ShowDialog() == true)
            {
                kManager2D.OnDocument2DCreated += KManager2D_OnDocument2DCreated;
                kManager2D.OnError += (massage) => { MessageBox.Show(massage); };

                kManager2D.CreateDocument(title.Title, 3, true);
            }

            title = null;
            kManager2D = null;
        }

        public void DrawLineSeg()
        {
            LineSeg lineSeg = new LineSeg(25, 30, 120, 50, 2);
            lineSeg.Draw();
        }

        public void GetViewParam()
        {
            new KompasDocument2D().GetViewPram();
        }

        #endregion

        #region Private Methods

        private void GetOpendKDocumentList()
        {
            KDrawings = KManager.GetDocumentsNameList();
            _selectedKDrawing = KDrawings.Where(kd => kd.Active == true).FirstOrDefault();
            NotifyOfPropertyChange(nameof(SelectedKDrawing));
        }

        private void KManager2D_OnDocument2DCreated(KDocumentItem kDocument)
        {
            if (kDocument != null)
            {
                MessageBox.Show($"Cоздан чертеж \"{kDocument.Name}\"");
                GetOpendKDocumentList();
            }
        }

        #endregion

        internal class TitleClass
        {
            [DisplayName("Название файла")]
            public string Title { get; set; }
        }
    }
}
