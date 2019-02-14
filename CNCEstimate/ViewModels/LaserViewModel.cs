using Caliburn.Micro;

namespace CNCEstimate.ViewModels
{
    public class LaserViewModel : Conductor<object>
    {
        public LaserViewModel()
        {
            ActivateItem(new MaterialSelectorViewModel());
        }
    }
}
