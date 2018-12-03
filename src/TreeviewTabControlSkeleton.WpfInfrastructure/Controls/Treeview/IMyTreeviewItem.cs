using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace TreeviewTabControlSkeleton.WpfInfrastructure.Controls.Treeview
{
    public interface IMyTreeviewItem
    {
        string Name { get; }
        Visibility Visibility { get; set; }
        ObservableCollection<IMyTreeviewItem> Items { get; set; }
        PathGeometry Icon { get;  }

        bool IsDisabled { get; set; }
        bool IsExpanded { get; set; }
        bool AllowReorder { get; set; }
        bool IsMainItem { get; }
        bool HasItems { get; }
    }
}
