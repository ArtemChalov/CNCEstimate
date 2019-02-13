using DbSqlServerWorker.Models;
using System;
using System.Windows;

namespace CNCEstimate
{
    public static class AppStore
    {
        #region Fieldes

        private static CuttingMachine _selectedMachine;
        private static Material _selectedMaterial;

        #endregion

        #region Properties

        public static CuttingMachine SelectedMachine
        {
            get { return _selectedMachine; }
            set
            {
                _selectedMachine = value;
                if (value != null)
                {
                    OnMachineSelected?.Invoke(value);
                }
            }
        }

        public static Material SelectedMaterial
        {
            get { return _selectedMaterial; }
            set
            {
                _selectedMaterial = value;
                if (value != null)
                {
                    OnMaterialSelected?.Invoke(value);
                }
            }
        }

        #endregion

        #region Events

        public static event Action<CuttingMachine> OnMachineSelected;
        public static event Action<Material> OnMaterialSelected;

        #endregion
    }
}
