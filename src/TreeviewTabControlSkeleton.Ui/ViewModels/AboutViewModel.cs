using System;

using Caliburn.Micro;

namespace TreeviewTabControlSkeleton.Ui.ViewModels
{
    public class AboutViewModel : PropertyChangedBase
    {
        private readonly Action<AboutViewModel> closeHandler;

        public AboutViewModel(Action<AboutViewModel> closeHandler)
        {
            this.closeHandler = closeHandler;
        }

        public void Close()
        {
            closeHandler(this);
        }
    }
}