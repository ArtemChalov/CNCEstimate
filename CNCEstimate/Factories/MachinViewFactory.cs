using Caliburn.Micro;
using CNCEstimate.ViewModels;

namespace CNCEstimate.Factories
{
    public class MachinViewFactory
    {
        string _machineName = "";
        public MachinViewFactory(string machineName)
        {
            _machineName = machineName;
        }

        public Screen GetView()
        {
            switch (_machineName)
            {
                case "Гидроабразивная резка":
                    return new HidroViewModel();
                case "Лазерная резка":
                    return new LaserViewModel();
                case "Плазменная резка":
                    return new PlasmaViewModel();
                case "Газовая резка":
                    return new GasViewModel();
                default: return null;
            }
        }
    }
}
