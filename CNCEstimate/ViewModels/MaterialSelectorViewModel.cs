using Caliburn.Micro;
using CNCEstimate.Dialogs;
using DbSqlServerWorker.DataLoaders;
using DbSqlServerWorker.Models;
using System;

namespace CNCEstimate.ViewModels
{
    public class MaterialSelectorViewModel : Screen
    {
        private string _materialTitle = "Выберите материал";

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
                Owner = AppStore.MainWindow
            };
            if (dialog.ShowDialog() == true)
            {
                AppStore.SelectedMaterial = dialog.SelectedMaterial;
                MaterialTitle =
                    $"Материал: {AppStore.SelectedMaterial.Title} ({MaterialLoader.FetchMaterialGostByMaterialGroupId(AppStore.SelectedMaterial.MaterialGroupId)})";
                OnMaterialChanged?.Invoke(dialog.SelectedMaterial);
            }
        }

        public Action<Material> OnMaterialChanged;
    }
}
