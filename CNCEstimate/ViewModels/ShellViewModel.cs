﻿using Caliburn.Micro;
using CNCEstimate.Dialogs;
using CNCEstimate.Factories;
using DbSqlServerWorker.Models;
using System.Windows;

namespace CNCEstimate.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            AppStore.OnMachineSelected += AppStore_OnMachineSelected;
            AppStore.MainWindow = (Window)this.GetView();
        }

        private void AppStore_OnMachineSelected(CuttingMachine machine)
        {
            if (machine != null)
            {
                ActivateItem(new MachinViewFactory(machine.TypeTitle).GetView());
            }
        }

        public void ChoseCutType()
        {
            ChooseCutMachineDialog dialog = new ChooseCutMachineDialog()
            {
                Owner = AppStore.MainWindow
            };
            dialog.SetCurrentMachine(AppStore.SelectedMachine);

            if(dialog.ShowDialog() == true)
            {
                AppStore.SelectedMachine = dialog.SelectedMachine;
            }
        }
    }
}
