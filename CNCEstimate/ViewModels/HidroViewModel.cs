using Caliburn.Micro;
using CNCEstimate.Dialogs;
using DbSqlServerWorker.DataLoaders;
using System.Windows;

namespace CNCEstimate.ViewModels
{
    public class HidroViewModel : Screen
    {
        private string _materialTitle;

        public string MaterialTitle
        {
            get { return _materialTitle; }
            set
            {
                _materialTitle = value;
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
                MaterialTitle = 
                    $"Материал: {AppStore.SelectedMaterial.Title} ({MaterialLoader.FetchMaterialGostByMaterialGroupId(AppStore.SelectedMaterial.MaterialGroupId)})";
            }
        }

    }
}
