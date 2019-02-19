using CNCEstimate.Dialogs;
using KompasNet;
using KompasNet.Documents;
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
            title.Title = "Новый чертеж";
            var window = new InputDataDialogWindow(title);
            window.Title = "Название файла";
            window.Owner = AppStore.MainWindow;

            if(window.ShowDialog() == true)
            {
                new CreateDocument2D().Create(title.Title, null);
            }
            title = null;
        }

        internal class TitleClass
        {
            [DisplayName("Название файла")]
            public string Title { get; set; }
        }
    }
}
