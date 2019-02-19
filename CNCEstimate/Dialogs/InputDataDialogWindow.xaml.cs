using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для InputDataDialogWindow.xaml
    /// </summary>
    public partial class InputDataDialogWindow : Window
    {
        private object _obj;

        public InputDataDialogWindow(object obj)
        {
            InitializeComponent();
            _obj = obj;
            CreateList();
        }

        private void CreateList()
        {
            if (_obj == null) return;

            var collection = GetPropertiesCollection(_obj);
            foreach (var item in collection)
            {
                StackContainer.Children.Add(item);
            }
        }

        private IEnumerable<StackPanel> GetPropertiesCollection(object obj)
        {
            List<StackPanel> list = new List<StackPanel>();
            foreach (var prop in obj.GetType().GetProperties())
            {
                DisplayNameAttribute MyAttribute = (DisplayNameAttribute)prop.GetCustomAttribute(typeof(DisplayNameAttribute));

                string atrRes = "";
                if (MyAttribute != null)
                {
                    atrRes = MyAttribute.DisplayName;
                    StackPanel stack = new StackPanel
                    {
                        Orientation = Orientation.Vertical
                    };

                    TextBox textBox = new TextBox() { FontSize = 16, Width = 200 };
                    Binding myBinding = new Binding(prop.Name);
                    myBinding.Source = obj;
                    myBinding.Path = new PropertyPath(prop.Name);
                    myBinding.Mode = BindingMode.TwoWay;
                    myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    BindingOperations.SetBinding(textBox, TextBox.TextProperty, myBinding);

                    stack.Children.Add(new TextBlock() { Text = atrRes, FontSize = 14, Width = 200 });
                    stack.Children.Add(textBox);

                    list.Add(stack);
                }
            }

            return list;
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            bool res = true;
            foreach (var prop in _obj.GetType().GetProperties())
            {
                if (prop.PropertyType == typeof(string))
                {
                    string str = prop.GetValue(_obj).ToString();
                    if (String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str))
                    {
                        DisplayNameAttribute MyAttribute = (DisplayNameAttribute)prop.GetCustomAttribute(typeof(DisplayNameAttribute));
                        MessageBox.Show($"Поле \"{MyAttribute.DisplayName}\" не может быть пустым!");
                        res = false;
                        break;
                    }
                }
            }

            if (res == false) return;

            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
