using System;
using System.Windows.Controls;

namespace CNCEstimate.Factories
{
    class InputDataPresenterItemFactory
    {
        string _tag;
        public InputDataPresenterItemFactory(string tag)
        {
            _tag = tag;
        }

        public StackPanel GetPresenter()
        {
            StackPanel panel = new StackPanel();
            switch (_tag)
            {
                case "Косынка": return CreateK(panel);
                case "Пластина": return CreateKP(panel);
            }

            panel = null;
            return null;
        }

        private StackPanel CreateKP(StackPanel panel)
        {
            //panel.Children.Add()

            return panel;
        }

        private StackPanel CreateK(StackPanel panel)
        {
            return panel;

        }
    }
}
