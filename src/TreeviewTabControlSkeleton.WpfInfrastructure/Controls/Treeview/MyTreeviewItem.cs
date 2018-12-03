using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace TreeviewTabControlSkeleton.WpfInfrastructure.Controls.Treeview
{
    public class MyTreeviewItem : PropertyChangedBase, IMyTreeviewItem
    {
        public MyTreeviewItem(string name, PathGeometry icon, bool isMainItem)
        {
            this.Name = name;
            this.Icon = icon;
            this.IsMainItem = isMainItem;
        }
        
        public string Name { get; set; }
        public Visibility Visibility { get; set; }
        public ObservableCollection<IMyTreeviewItem> Items { get; set; }
        public PathGeometry Icon { get; set; }

        public bool IsDisabled { get; set; }
        public bool IsExpanded { get; set; }
        public bool AllowReorder { get; set; }
        public bool IsMainItem { get; }
        public bool HasItems { get { return Items != null || Items.Count > 0; } }
    }
}
