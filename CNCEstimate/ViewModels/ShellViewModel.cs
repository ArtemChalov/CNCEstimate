using Caliburn.Micro;
using CNCEstimate.Dialogs;
using CNCEstimate.Factories;
using DbSqlServerWorker;
using DbSqlServerWorker.Models;
using System.Collections.Generic;
using System.Windows;

namespace CNCEstimate.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private List<MaterialGroup> _material;
        private string _selectedMater;

        public ShellViewModel()
        {
            MaterialGroups = DataLoader.FetchMaterialGroups();
            IsVisibleMaterialBox = false;
            AppStore.OnMachineSelected += AppStore_OnMachineSelected;
        }

        private void AppStore_OnMachineSelected(CuttingMachine machine)
        {
            if (machine != null)
            {
                IsVisibleMaterialBox = true;
                ActivateItem(new MachinViewFactory(machine.TypeTitle).GetView());
            }
            NotifyOfPropertyChange(nameof(IsVisibleMaterialBox));
        }

        public bool IsVisibleMaterialBox { get; private set; }

        public List<MaterialGroup> MaterialGroups
        {
            get { return _material; }
            set { _material = value; }
        }

        public string SelectedMater
        {
            get { return _selectedMater; }
            set
            {
                _selectedMater = value;
                if (value != null && value != "Выберите материал")
                {
                    MessageBox.Show(value);
                }
            }
        }

        public void ChoseCutType()
        {
            ChooseCutMachineDialog dialog = new ChooseCutMachineDialog()
            {
                Owner = (Window)this.GetView()
            };
            dialog.SetCurrentMachine(AppStore.SelectedMachine);

            if(dialog.ShowDialog() == true)
            {
                AppStore.SelectedMachine = dialog.SelectedMachine;
            }
        }
    }
}
