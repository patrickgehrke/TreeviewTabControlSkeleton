using System.Collections.ObjectModel;
using TreeviewTabControlSkeleton.WpfInfrastructure.Logos;
using TreeviewTabControlSkeleton.WpfInfrastructure.Models;

namespace TreeviewTabControlSkeleton.Ui.Generators
{
    public class TreeViewGenerator : ITreeViewGenerator
    {
        public ObservableCollection<TreeNodeModel> Generate()
        {
            var treeNodes = new ObservableCollection<TreeNodeModel>();

            treeNodes.Add(new TreeNodeModel("Dashboard", LogoResources.Database, true, false));

            treeNodes.Add(new TreeNodeModel("Accounts", LogoResources.Database, true, false));
            treeNodes[1].Childs = new ObservableCollection<TreeNodeModel>();
            treeNodes[1].Childs.Add(new TreeNodeModel("Dummy", LogoResources.PlayerProfile, false, false));

            return treeNodes;
        }
    }

    public interface ITreeViewGenerator
    {
        ObservableCollection<TreeNodeModel> Generate();
    }
}
