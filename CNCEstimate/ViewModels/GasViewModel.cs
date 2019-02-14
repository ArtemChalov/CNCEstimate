using Caliburn.Micro;

namespace CNCEstimate.ViewModels
{
    public class GasViewModel : Conductor<object>
    {
        public GasViewModel()
        {
            ActivateItem(new MaterialSelectorViewModel());
        }
    }
}
