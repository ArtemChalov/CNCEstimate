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
        public InputDataDialogWindow(object obj)
        {
            InitializeComponent();
            CreateList(obj);
        }

        private void CreateList(object obj)
        {
            var collection = GetPropertiesCollection(obj);
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
                }
                //MessageBox.Show($"{prop.Name} - {prop.GetValue(obj)?.ToString()} - {atrRes}");

                StackPanel stack = new StackPanel
                {
                    Orientation = Orientation.Vertical
                };

                stack.Children.Add(new TextBlock() { Text = atrRes, FontSize = 14, Width = 200 });
                stack.Children.Add(new TextBox() { FontSize = 16, Width = 200});

                list.Add(stack);
            }

            return list;
        }
    }
}
