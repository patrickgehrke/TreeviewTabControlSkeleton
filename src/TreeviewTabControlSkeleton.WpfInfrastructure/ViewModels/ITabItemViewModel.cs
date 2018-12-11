using System.Windows.Media;
using TreeviewTabControlSkeleton.WpfInfrastructure.Enums;

namespace TreeviewTabControlSkeleton.WpfInfrastructure.ViewModels
{
    public interface ITabItemViewModel
    {
        PathGeometry Icon { get; }

        bool AllowMultiLoad { get; }

        LoadingState CurrentLoadingState { get; }
    }
}