using MahApps.Metro.Controls;
using System.Windows.Controls;
using System.Windows.Input;
using TreeviewTabControlSkeleton.WpfInfrastructure.Models;

namespace TreeviewTabControlSkeleton.Ui.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : MetroWindow
    {
        public ShellView()
        {
            InitializeComponent();
        }

        private void TreeView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var tree = sender as TreeView;
            if(tree != null)
            {
                var leaf = tree.SelectedItem as TreeNodeModel;
                if (leaf != null)
                    if (leaf.IsRootNode && e.ClickCount == 2)
                        e.Handled = true;
            }
        }
    }
}