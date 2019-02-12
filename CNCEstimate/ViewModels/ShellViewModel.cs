using Caliburn.Micro;
using DbSqlServerWorker;
using DbSqlServerWorker.Models;
using System.Collections.Generic;
using System.Windows;

namespace CNCEstimate.ViewModels
{
    public class ShellViewModel : Screen
    {
        private List<MaterialGroup> _material;
        private string _selectedMater;
        private List<CuttingMachine> _cuttingType;
        private string _selectedCuttingType;

        public ShellViewModel()
        {
            MaterialGroups = DataLoader.FetchMaterialGroups();

            CuttingType = DataLoader.FetchCuttingMachine();

            IsVisibleMaterialBox = false;
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

        public bool IsVisibleMaterialBox { get; private set; }

        public List<CuttingMachine> CuttingType
        {
            get { return _cuttingType; }
            set { _cuttingType = value; }
        }

        public string SelectedCuttingType
        {
            get { return _selectedCuttingType; }
            set
            {
                _selectedCuttingType = value;
                if (value != null && value != "Выберите тип резки")
                {
                    IsVisibleMaterialBox = true;
                }
                else
                {
                    IsVisibleMaterialBox = false;
                    MaterialGroups = null;
                }
                NotifyOfPropertyChange(nameof(IsVisibleMaterialBox));
            }
        }

        public void FirstMethodEx()
        {

        }
    }
}
