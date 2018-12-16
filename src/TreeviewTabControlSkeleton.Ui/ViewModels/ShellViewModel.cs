using Caliburn.Micro;
using System.Windows.Media;
using System.Collections.ObjectModel;
using TreeviewTabControlSkeleton.Ui.Common;
using TreeviewTabControlSkeleton.WpfInfrastructure.Logos;
using TreeviewTabControlSkeleton.WpfInfrastructure.ViewModels;
using System.Collections.Generic;
using TreeviewTabControlSkeleton.Ui.Coroutines;
using MahApps.Metro.Controls.Dialogs;

namespace TreeviewTabControlSkeleton.Ui.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive
    {
        private readonly ITabItemGenerator tabItemGenerator;
        private readonly IDialogCoordinator dialogCoordinator;

        public ShellViewModel(ITabItemGenerator tabItemGenerator, IDialogCoordinator dialogCoordinator)
        {
            this.Message = "Hello World!";
            this.Version = "1.0 DEBUG";
            this.tabItemGenerator = tabItemGenerator;
            this.dialogCoordinator = dialogCoordinator;
            this.ApplicationLogo = LogoResources.Github;
            this.TreeNodes = new ObservableCollection<TreeNodeViewModel>();

            /*TODO: dynamic treeview from database entries */
            this.TreeNodes.Add(new TreeNodeViewModel("Dashboard", LogoResources.Database, true, false));
            this.TreeNodes[0].Childs = new ObservableCollection<TreeNodeViewModel>();
            this.TreeNodes[0].Childs.Add(new TreeNodeViewModel("Dummy", LogoResources.PlayerProfile, false, false));
        }

        public void CloseTabItem()
        {
            var tabItem = base.Items[this.selectedTabIndex];
            base.DeactivateItem(tabItem, true);
            this.tabItemGenerator.Release(tabItem);
        }

        public IEnumerable<IResult> CreateTabItem(TreeNodeViewModel treeNode)
        {
            yield return new TabItemMultiLoadResult(treeNode.Name, treeNode.CanOpenMultipleTabItems, base.Items)
                .WhenCancelled(() => new MessageBoxCancellationResult(dialogCoordinator, 
                                                                      "Multiple tabs from the selection are not allowed", 
                                                                      "Multiload not allowed"));
            
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
