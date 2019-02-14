using Caliburn.Micro;
using DbSqlServerWorker.Models;

namespace CNCEstimate.ViewModels
{
    public class GasViewModel : Conductor<IScreen>.Collection.AllActive
    {
        public MaterialSelectorViewModel MaterialSelectorItem { get; set; } = new MaterialSelectorViewModel();

        public ProductSelectorViewModel ProductSelectorItem { get; set; }

        public GasViewModel()
        {
            MaterialSelectorItem.OnMaterialChanged = OnMaterialChanged;
        }

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
