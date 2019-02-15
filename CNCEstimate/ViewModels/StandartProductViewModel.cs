using Caliburn.Micro;

namespace CNCEstimate.ViewModels
{
    public class StandartProductViewModel : Screen
    {
        string _tag;
        public StandartProductViewModel(string tag)
        {
            _tag = tag;
        }

        public string Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

    }
}
