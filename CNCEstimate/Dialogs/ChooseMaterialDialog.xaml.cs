using DbSqlServerWorker.DataLoaders;
using DbSqlServerWorker.Models;
using System.Windows;
using System.Windows.Controls;


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
            TopGroup.ItemsSource = MaterialLoader.FetchMaterialGroupsByParent();
        }

        public Material SelectedMaterial { get; private set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (AppStore.SelectedMaterial != null)
            {
                var matGroup = MaterialLoader.FetchMaterialGroupsByGroupId(AppStore.SelectedMaterial.MaterialGroupId);

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
                InnerGroup.ItemsSource = MaterialLoader.FetchMaterialGroupsByParent(((MaterialGroup)TopGroup.SelectedItem).GroupTitle);
            }
        }

        private void InnerGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InnerGroup.SelectedItem != null)
            {
                MaterialList.ItemsSource = null;
                MaterialList.ItemsSource = MaterialLoader.FetchMaterialsByGroupId(((MaterialGroup)InnerGroup.SelectedItem).MaterialGroupId);
            }
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialList.SelectedItem != null)
            {
                SelectedMaterial = (Material)MaterialList.SelectedItem;
                this.DialogResult = true;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
