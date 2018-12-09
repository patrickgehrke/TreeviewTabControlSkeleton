using Caliburn.Micro;
using TreeviewTabControlSkeleton.WpfInfrastructure.Enums;

namespace TreeviewTabControlSkeleton.WpfInfrastructure.ViewModels
{
    public class ViewModelBase : Screen
    {
        private LoadingState currentLoadingState;
        public LoadingState CurrentLoadingState
        {
            get { return this.currentLoadingState; }
            private set
            {
                if (value == this.currentLoadingState)
                    return;
                this.currentLoadingState = value;
                this.NotifyOfPropertyChange(nameof(this.CurrentLoadingState));
            }
        }
    }
}
