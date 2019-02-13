using DbSqlServerWorker;
using DbSqlServerWorker.Models;
using System.Windows;

namespace CNCEstimate.Dialogs
{
    /// <summary>
    /// Fetch Cutting Machine list from database
    /// then returns a selected machine instance with the SelectedMachine property.
    /// </summary>
    public partial class ChooseCutMachineDialog : Window
    {
        public ChooseCutMachineDialog()
        {
            InitializeComponent();
            CutMachines.ItemsSource = DataLoader.FetchCuttingMachine();
            CutMachines.SelectedIndex = 0;
        }

        public CuttingMachine SelectedMachine { get; private set; }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            SelectedMachine = (CuttingMachine)CutMachines.SelectedItem;
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
