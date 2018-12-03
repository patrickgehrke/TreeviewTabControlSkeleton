using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.Windows.Media;
using TreeviewTabControlSkeleton.WpfInfrastructure.Controls.Treeview;
using TreeviewTabControlSkeleton.WpfInfrastructure.Logos;

namespace TreeviewTabControlSkeleton.Ui.ViewModels
{
    public class ShellViewModel : Screen
    {
        public ShellViewModel()
        {
            this.Message = "Hello World!";
            this.Version = "1.0 DEBUG";

            /*will be replaced - dynamic treeview from database */
            this.TreeviewItems = new ObservableCollection<IMyTreeviewItem>();
            this.TreeviewItems.Add(new MyTreeviewItem("DASHBOARD", LogoResources.Database, true));
            this.TreeviewItems[0].Items = new ObservableCollection<IMyTreeviewItem>();
            this.TreeviewItems[0].Items.Add(new MyTreeviewItem("FIRST CHILD", LogoResources.PlayerProfile, false));
            
        }

        public PathGeometry ApplicationLogo = LogoResources.Github;

        public string Message { get; set; }

        public string Version { get; set; }

        public ObservableCollection<IMyTreeviewItem> TreeviewItems { get; set; }
    }
}
