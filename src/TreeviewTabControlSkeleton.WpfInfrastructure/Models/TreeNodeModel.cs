using System.Windows.Media;
using System.Collections.ObjectModel;

using Caliburn.Micro;

namespace TreeviewTabControlSkeleton.WpfInfrastructure.Models
{
    public class TreeNodeModel : PropertyChangedBase
    {
        public TreeNodeModel(string name, PathGeometry icon, bool isRootNode, bool canOpenMultipleTabItems)
        {
            this.Name = name;
            this.Icon = icon;
            this.IsRootNode = isRootNode;
            this.CanOpenMultipleTabItems = canOpenMultipleTabItems;
            this.Childs = new ObservableCollection<TreeNodeModel>();
        }

        public string Name { get; }

        public PathGeometry Icon { get; }

        public bool IsRootNode { get; }

        public bool CanOpenMultipleTabItems { get; }

        public bool IsExpanded { get; set; }

        public ObservableCollection<TreeNodeModel> Childs { get; set; }
    }
}
