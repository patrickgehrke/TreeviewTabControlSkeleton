using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

            /*TODO: dynamic treeview from database entries */
            this.TreeNodes.Add(new TreeNodeViewModel("Dashboard", LogoResources.Database, true));
            this.TreeNodes[0].Childs = new ObservableCollection<TreeNodeViewModel>();
            this.TreeNodes[0].Childs.Add(new TreeNodeViewModel("Dummy", LogoResources.PlayerProfile, false));
        }

        public void CloseTabItem()
        {
            base.DeactivateItem(this.SelectedTabItem, true);
        }

        public void CreateTabItem(TreeNodeViewModel treeNode)
        {
            /*TODO: replace with CW Factory*/
            var tabItem = new DummyViewModel(treeNode.Name, false, treeNode.Icon);
            base.ActivateItem(tabItem);
            this.SelectedTabItem = tabItem;
        }

        private IScreen selectedTabItem;
        public IScreen SelectedTabItem
        {
            get => selectedTabItem;
            set
            {
                if(null != value)
                {
                    this.selectedTabItem = value;
                    base.NotifyOfPropertyChange(nameof(SelectedTabItem));
                }
            }
        }

        public string Message { get; }

        public string Version { get; }

        public PathGeometry ApplicationLogo { get; }

        public ObservableCollection<TreeNodeViewModel> TreeNodes { get; set; }
    }
}
