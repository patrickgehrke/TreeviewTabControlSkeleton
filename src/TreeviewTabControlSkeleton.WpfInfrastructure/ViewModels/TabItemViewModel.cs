using System.Windows.Media;

namespace TreeviewTabControlSkeleton.WpfInfrastructure.ViewModels
{
    public class TabItemViewModel : ViewModelBase
    {
        public TabItemViewModel(string name, bool allowMultiLoad, PathGeometry icon)
        {
            this.Icon = icon;
            base.DisplayName = name;
            this.AllowMultiLoad = allowMultiLoad;
        }
        
        public PathGeometry Icon { get; private set; }

        public bool AllowMultiLoad { get; private set; }
    }
}
