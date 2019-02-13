using Caliburn.Micro;
using CNCEstimate.Dialogs;
using System.Windows;

namespace CNCEstimate.ViewModels
{
    public class LaserViewModel : Screen
    {
        private string _materialTitle;

        public string MaterialTitle
        {
            get { return _materialTitle; }
            set
            {
                _materialTitle = "Материал: " + value;
                NotifyOfPropertyChange(nameof(MaterialTitle));
            }
        }

        public void SelectMaterial()
        {
            ChooseMaterialDialog dialog = new ChooseMaterialDialog()
            {
                Owner = (Window)((ShellViewModel)this.Parent).GetView()
            };
            if (dialog.ShowDialog() == true)
            {
                AppStore.SelectedMaterial = dialog.SelectedMaterial;
                MaterialTitle = AppStore.SelectedMaterial.Title;
            }
        }
    }
}
