using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.Windows.Media;
using TreeviewTabControlSkeleton.WpfInfrastructure.Logos;
using TreeviewTabControlSkeleton.WpfInfrastructure.ViewModels;

namespace TreeviewTabControlSkeleton.Ui.ViewModels
{
    public class ShellViewModel : Screen
    {
        public ShellViewModel()
        {
            this.Message = "Hello World!";
            this.Version = "1.0 DEBUG";

            /*will be replaced - dynamic treeview from database */
            this.TreeNodes = new ObservableCollection<TreeNodeViewModel>();
            this.TreeNodes.Add(new TreeNodeViewModel("Dashboard", LogoResources.Database, true));
            this.TreeNodes[0].Childs = new ObservableCollection<TreeNodeViewModel>();
            this.TreeNodes[0].Childs.Add(new TreeNodeViewModel("first child", LogoResources.PlayerProfile, false));
        }

        public PathGeometry ApplicationLogo = LogoResources.Github;

        public string Message { get; set; }

        public string Version { get; set; }

        public ObservableCollection<TreeNodeViewModel> TreeNodes { get; set; }
    }
}
