using Caliburn.Micro;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CNCEstimate.ViewModels
{
    public class StandartProductViewModel : Screen
    {
        string _tagName;
        BitmapImage _imageSrc;
        private StackPanel _inputDataPresenter;

        public StandartProductViewModel(string tag)
        {
            _tagName = tag;
            ImageSrc = WriteableBitmapEx.BitmapImageFactory.CreateFromFile($"{System.AppDomain.CurrentDomain.BaseDirectory}\\{_tagName}.png");
            _inputDataPresenter = new StackPanel();
            _inputDataPresenter.Children.Add(new TextBlock() { Text = "Hello" });
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
                NotifyOfPropertyChange(nameof(ImageSrc));
            }
        }

        public StackPanel InputDataPresenter
        {
            get { return _inputDataPresenter; }
            set { _inputDataPresenter = value;
                NotifyOfPropertyChange(nameof(InputDataPresenter));
            }
        }
    }
}
