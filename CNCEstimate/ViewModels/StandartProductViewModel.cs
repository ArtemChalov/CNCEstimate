using Caliburn.Micro;
using CNCEstimate.Models.Figures;
using Primitives;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CNCEstimate.ViewModels
{
    public class StandartProductViewModel : Screen
    {
        string _tagName;
        BitmapImage _imageSrc;
        private StackPanel _inputDataPresenter;
        private BindableCollection<PlateFigure> _FigureItems;

        public StandartProductViewModel(string tag)
        {
            _tagName = tag;
            ImageSrc = WriteableBitmapEx.BitmapImageFactory.CreateFromFile($"{System.AppDomain.CurrentDomain.BaseDirectory}\\{_tagName}.png");
            _inputDataPresenter = new StackPanel();
            _inputDataPresenter.Children.Add(new TextBlock() { Text = "Hello" });
            _FigureItems = new BindableCollection<PlateFigure>()
            {
                new PlateFigure(new LineObj(2, 200, 0.7), new LineObj(2, 300, 0.7), new LineObj(2, 20, 0.7), new LineObj(2, 20, 0.7))
            };
        }

        public string TagName
        {
            get { return _tagName; }
            set { _tagName = value; }
        }

        public BitmapImage ImageSrc
        {
            get { return _imageSrc; }
            set
            {
                _imageSrc = value;
                NotifyOfPropertyChange();
            }
        }

        public StackPanel InputDataPresenter
        {
            get { return _inputDataPresenter; }
            set { _inputDataPresenter = value;
                NotifyOfPropertyChange();
            }
        }

        public BindableCollection<PlateFigure> FigureItems
        {
            get { return _FigureItems; }
            set
            {
                _FigureItems = value;
                NotifyOfPropertyChange();
            }
        }
    }
}
