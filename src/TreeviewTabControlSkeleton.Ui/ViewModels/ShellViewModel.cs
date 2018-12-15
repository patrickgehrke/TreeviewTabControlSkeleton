using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Media;
using TreeviewTabControlSkeleton.Ui.Common;
using TreeviewTabControlSkeleton.WpfInfrastructure.Logos;
using TreeviewTabControlSkeleton.WpfInfrastructure.ViewModels;

namespace TreeviewTabControlSkeleton.Ui.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive
    {
        private readonly ITabItemGenerator tabItemGenerator;

        public ShellViewModel(ITabItemGenerator viewModelFactory)
        {
            this.Message = "Hello World!";
            this.Version = "1.0 DEBUG";
            this.ApplicationLogo = LogoResources.Github;

            this.TreeNodes = new ObservableCollection<TreeNodeViewModel>();

            /*TODO: dynamic treeview from database entries */
            this.TreeNodes.Add(new TreeNodeViewModel("Dashboard", LogoResources.Database, true));
            this.TreeNodes[0].Childs = new ObservableCollection<TreeNodeViewModel>();
            this.TreeNodes[0].Childs.Add(new TreeNodeViewModel("Dummy", LogoResources.PlayerProfile, false));
            this.tabItemGenerator = viewModelFactory;
        }

        public void CloseTabItem()
        {
            var tabItem = base.Items[this.selectedTabIndex];
            base.DeactivateItem(tabItem, true);
            this.tabItemGenerator.Release(tabItem);
        }

        public void CreateTabItem(TreeNodeViewModel treeNode)
        {
            var tabItem = this.tabItemGenerator.Create(treeNode.Name, false, treeNode.Icon);
            base.ActivateItem(tabItem);
            this.SelectedTabIndex = base.Items.Count - 1;
        }

        private int selectedTabIndex;
        public int SelectedTabIndex
        {
            get => this.selectedTabIndex;
            set
            {
                this.selectedTabIndex = value;
                base.NotifyOfPropertyChange(nameof(SelectedTabIndex));
                
            }
        }

        public string Message { get; }

        public string Version { get; }

        public PathGeometry ApplicationLogo { get; }

        public ObservableCollection<TreeNodeViewModel> TreeNodes { get; set; }
    }
}
