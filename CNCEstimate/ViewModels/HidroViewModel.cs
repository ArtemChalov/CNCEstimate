﻿using Caliburn.Micro;

namespace CNCEstimate.ViewModels
{
    public class HidroViewModel : Conductor<object>
    {
        public HidroViewModel()
        {
            ActivateItem(new MaterialSelectorViewModel());
        }
    }
}
