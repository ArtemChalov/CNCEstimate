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
            if (AppStore.SelectedMaterial != null)
            {
                var matGroup = DataLoader.FetchMaterialGroupsByGroupId(AppStore.SelectedMaterial.MaterialGroupId);

                if (TopGroup.ItemsSource != null && matGroup != null)
                {
                    foreach (MaterialGroup item in TopGroup.ItemsSource)
                    {
                        if (item.GroupTitle == matGroup.Parent)
                        {
                            TopGroup.SelectedItem = item;
                            break;
                        }
                    }
                }

                if (InnerGroup.ItemsSource != null)
                {
                    InnerGroup.SelectedItem = matGroup;
                    InnerGroup_SelectionChanged(null, null);
                    MaterialList.SelectedItem = AppStore.SelectedMaterial;
                }
            }
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
            if (MaterialList.SelectedItem != null)
            {
                AppStore.SelectedMaterial = (Material)MaterialList.SelectedItem;
                this.DialogResult = true;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
