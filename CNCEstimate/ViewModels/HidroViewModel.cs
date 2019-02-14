using Caliburn.Micro;
using CNCEstimate.Dialogs;
using DbSqlServerWorker.DataLoaders;
using System.Windows;

namespace CNCEstimate.ViewModels
{
    public class HidroViewModel : Conductor<object>
    {
        public HidroViewModel()
        {
            ActivateItem(new MaterialSelectorViewModel());
        }
    }
}
