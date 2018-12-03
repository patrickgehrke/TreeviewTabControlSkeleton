using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TreeviewTabControlSkeleton.WpfInfrastructure.Controls.Treeview
{
    /// <summary>
    /// Interaction logic for MyTreeview.xaml
    /// </summary>
    public partial class MyTreeview : UserControl
    {
        public MyTreeview()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TreeViewEntriesProperty =
            DependencyProperty.Register("TreeViewEntries",
                                        typeof(ObservableCollection<IMyTreeviewItem>),
                                        typeof(MyTreeview),
                                        new PropertyMetadata(default(ObservableCollection<IMyTreeviewItem>)));

        public ObservableCollection<IMyTreeviewItem> TreeViewEntries
        {
            get { return (ObservableCollection<IMyTreeviewItem>)GetValue(TreeViewEntriesProperty); }
            set { SetValue(TreeViewEntriesProperty, value); }
        }

        public static readonly DependencyProperty AccentColorProperty = 
            DependencyProperty.Register("AccentColor",
                                        typeof(Brush),
                                        typeof(MyTreeview),
                                        new PropertyMetadata(default(Brush)));

        public Brush AccentColor
        {
            get { return (Brush)this.GetValue(AccentColorProperty); }
            set { this.SetValue(AccentColorProperty, value); }
        }

        public static readonly DependencyProperty ItemsColorProperty = 
            DependencyProperty.Register("ItemsColor",
                                        typeof(Brush),
                                        typeof(MyTreeview),
                                        new PropertyMetadata(Brushes.Black));

        public Brush ItemsColor
        {
            get { return (Brush)this.GetValue(ItemsColorProperty); }
            set { this.SetValue(ItemsColorProperty, value); }
        }
    }
}
