using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.Windows.Media;
using TreeviewTabControlSkeleton.WpfInfrastructure.Logos;
using TreeviewTabControlSkeleton.WpfInfrastructure.ViewModels;

namespace TreeviewTabControlSkeleton.Ui.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public ShellViewModel()
        {
            this.Message = "Hello World!";
            this.Version = "1.0 DEBUG";
            this.ApplicationLogo = LogoResources.Github;

            this.TreeNodes = new ObservableCollection<TreeNodeViewModel>();

            /*will be replaced - dynamic treeview from database */
            this.TreeNodes.Add(new TreeNodeViewModel("Dashboard", LogoResources.Database, true));
            this.TreeNodes[0].Childs = new ObservableCollection<TreeNodeViewModel>();
            this.TreeNodes[0].Childs.Add(new TreeNodeViewModel("first child", LogoResources.PlayerProfile, false));

            base.Items.Add(new TabItemViewModel("Dashboard", false, LogoResources.PlayerProfile));
            base.Items.Add(new TabItemViewModel("First Child", false, LogoResources.PlayerProfile));
        }

        public string Message { get; }

        public string Version { get; }

        public PathGeometry ApplicationLogo { get; }

        public ObservableCollection<TreeNodeViewModel> TreeNodes { get; set; }
    }
}
