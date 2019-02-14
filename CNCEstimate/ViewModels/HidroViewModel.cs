using Caliburn.Micro;
using DbSqlServerWorker.Models;

namespace CNCEstimate.ViewModels
{
    public class HidroViewModel : Conductor<IScreen>.Collection.AllActive
    {
        public HidroViewModel()
        {
            MaterialSelectorItem = new MaterialSelectorViewModel()
            {
                OnMaterialChanged = OnMaterialChanged
            };
        }

        public MaterialSelectorViewModel MaterialSelectorItem { get; set; }

        public ProductSelectorViewModel ProductSelectorItem { get; set; }

        private void OnMaterialChanged(Material material)
        {
            if (ProductSelectorItem == null)
            {
                ProductSelectorItem = new ProductSelectorViewModel(material);
                NotifyOfPropertyChange(nameof(ProductSelectorItem));
            }
            else
                ProductSelectorItem.Material = material;
        }
    }
}

