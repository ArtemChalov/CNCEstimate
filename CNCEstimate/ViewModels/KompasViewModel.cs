using CNCEstimate.Dialogs;
using CNCEstimate.Models;
using KompasNet;
using KompasNet.Documents;
using KompasNet.Models;
using System;
using System.ComponentModel;

namespace CNCEstimate.ViewModels
{
    public class KompasViewModel
    {

        public void Open()
        {
            KompasObjectFactory.Open();
        }

        public void Close()
        {
            KompasObjectFactory.Close();
        }

        public void Create2D()
        {
            var title = new TitleClass();
            var window = new InputDataDialogWindow(title);
            window.Title = "Название файла";
            window.Owner = AppStore.MainWindow;

            window.ShowDialog();

            //new CreateDocument2D().Create("Новый документ", null);
        }

        internal class TitleClass
        {
            [DisplayName("Название файла")]
            public string Title { get; set; }
        }
    }
}
