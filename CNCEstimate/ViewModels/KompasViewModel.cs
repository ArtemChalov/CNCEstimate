using CNCEstimate.Dialogs;
using KompasNet;
using KompasNet.Documents;
using KompasNet.Drawing2D;
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
