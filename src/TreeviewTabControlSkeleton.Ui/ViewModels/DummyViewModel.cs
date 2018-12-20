using System.Windows.Media;
using TreeviewTabControlSkeleton.WpfInfrastructure.Enums;
using TreeviewTabControlSkeleton.WpfInfrastructure.ViewModelContracts;

namespace TreeviewTabControlSkeleton.Ui.ViewModels
{
    public class DummyViewModel : ViewModelBase, ITabItemViewModel
    {
        public DummyViewModel(string name, bool allowMultiLoad, PathGeometry icon)
        {
            this.Icon = icon;
            base.DisplayName = name;
            this.AllowMultiLoad = allowMultiLoad;
        }

        public PathGeometry Icon { get; }

        public bool AllowMultiLoad { get; }

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

        public void SetLoadingState()
        {
            this.CurrentLoadingState = LoadingState.Indeterminate;
        }

        public void UnsetLoadingState()
        {
            this.CurrentLoadingState = LoadingState.None;
        }
    }
}
