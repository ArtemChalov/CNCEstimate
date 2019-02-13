using DbSqlServerWorker;
using DbSqlServerWorker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CNCEstimate.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для ChooseMaterialDialog.xaml
    /// </summary>
    public partial class ChooseMaterialDialog : Window
    {
        public ChooseMaterialDialog()
        {
            InitializeComponent();
            TopGroup.ItemsSource = DataLoader.FetchMaterialGroupsByParent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TopGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TopGroup.SelectedItem != null)
            {
                InnerGroup.ItemsSource = null;
                MaterialList.ItemsSource = null;
                MaterialList.SelectedItem = null;
                InnerGroup.ItemsSource = DataLoader.FetchMaterialGroupsByParent(((MaterialGroup)TopGroup.SelectedItem).GroupTitle);
            }
        }

        private void InnerGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InnerGroup.SelectedItem != null)
            {
                MaterialList.ItemsSource = null;
                MaterialList.ItemsSource = DataLoader.FetchMaterialsByGroupId(((MaterialGroup)InnerGroup.SelectedItem).MaterialGroupId);
            }
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            //SelectedMachine = (CuttingMachine)CutMachines.SelectedItem;
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
