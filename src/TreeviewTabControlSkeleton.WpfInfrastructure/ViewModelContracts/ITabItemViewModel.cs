using System.Windows.Media;
using TreeviewTabControlSkeleton.WpfInfrastructure.Enums;

namespace TreeviewTabControlSkeleton.WpfInfrastructure.ViewModelContracts
{
    public interface ITabItemViewModel
    {
        PathGeometry Icon { get; }

        bool AllowMultiLoad { get; }

        LoadingState CurrentLoadingState { get; }
    }
}