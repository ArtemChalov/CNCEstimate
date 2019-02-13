using DbSqlServerWorker.Models;
using System;

namespace CNCEstimate
{
    public static class AppStore
    {
        #region Fieldes

        private static CuttingMachine _selectedMachine;

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

        #endregion

        #region Events

        public static event Action<CuttingMachine> OnMachineSelected;

        #endregion
    }
}
