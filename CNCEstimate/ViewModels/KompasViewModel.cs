using KompasNet;
using KompasNet.Documents;
using KompasNet.Models;

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
            CreateDocument2D.Create("Новый документ", new MainStamp("Чалов", "Деталь","000.001", "Ст3сп", "ООО\n\"АгроПермьКомплекс\""));
        }
    }
}
