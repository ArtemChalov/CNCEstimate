using Caliburn.Micro;
using DbSqlServerWorker.Models;

namespace CNCEstimate.ViewModels
{
    public class ProductSelectorViewModel : Screen
    {
        private Material _material;

        public ProductSelectorViewModel(Material material)
        {
            _material = material;
        }

        public Material Material
        {
            get { return _material; }
            set { _material = value; }
        }
    }
}
