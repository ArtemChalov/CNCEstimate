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
        private CuttingMachine _selectedCuttingMachine;

        public ShellViewModel()
        {
            MaterialGroups = DataLoader.FetchMaterialGroups();

            IsVisibleMaterialBox = false;
        }

        public bool IsVisibleMaterialBox { get; private set; }

        public CuttingMachine SelectedCuttingMachine
        {
            get { return _selectedCuttingMachine; }
            set
            {
                _selectedCuttingMachine = value;
                if (value != null)
                {
                    IsVisibleMaterialBox = true;
                    ActivateItem(new MachinViewFactory(value.TypeTitle).GetView());
                }
                NotifyOfPropertyChange(nameof(IsVisibleMaterialBox));
                NotifyOfPropertyChange(nameof(SelectedCuttingMachine));
            }
        }

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
            dialog.SetCurrentMachine(SelectedCuttingMachine);

            if(dialog.ShowDialog() == true)
            {
                SelectedCuttingMachine = dialog.SelectedMachine;
            }
        }
    }
}
