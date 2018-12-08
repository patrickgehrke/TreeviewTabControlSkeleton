using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace TreeviewTabControlSkeleton.WpfInfrastructure.ViewModels
{
    public class TreeNodeViewModel : PropertyChangedBase
    {
        public TreeNodeViewModel(string name, PathGeometry icon, bool isRootNode)
        {
            this.Name = name;
            this.Icon = icon;
            this.IsRootNode = isRootNode;
            this.Childs = new ObservableCollection<TreeNodeViewModel>();
        }

        public string Name { get; }

        public PathGeometry Icon { get; }

        public bool IsRootNode { get; }

        public ObservableCollection<TreeNodeViewModel> Childs { get; set; }
    }
}