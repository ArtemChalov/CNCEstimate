using Caliburn.Micro;

namespace CNCEstimate.ViewModels
{
    public class PlasmaViewModel : Conductor<object>
    {
        public PlasmaViewModel()
        {
            ActivateItem(new MaterialSelectorViewModel());
        }
    }
}
