using System;
using System.Windows.Media;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;

using TreeviewTabControlSkeleton.Ui.Views;
using TreeviewTabControlSkeleton.Ui.Generators;
using TreeviewTabControlSkeleton.Ui.Coroutines.TabItem;
using TreeviewTabControlSkeleton.WpfInfrastructure.Logos;
using TreeviewTabControlSkeleton.WpfInfrastructure.Models;
using TreeviewTabControlSkeleton.Ui.Coroutines.MessageBox;
using TreeviewTabControlSkeleton.WpfInfrastructure.ViewModelContracts;

namespace TreeviewTabControlSkeleton.Ui.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive
    {
        private readonly ITabItemGenerator tabItemGenerator;
        private readonly ITreeViewGenerator treeViewGenerator;
        private readonly IDialogCoordinator dialogCoordinator;

        public ShellViewModel(ITabItemGenerator tabItemGenerator, 
                              ITreeViewGenerator treeViewGenerator,
                              IDialogCoordinator dialogCoordinator)
        {
            this.Version = "1.0 DEBUG";
            this.Message = "Hello World!";
            this.tabItemGenerator = tabItemGenerator;
            this.treeViewGenerator = treeViewGenerator;
            this.dialogCoordinator = dialogCoordinator;
            this.ApplicationLogo = LogoResources.Github;
            this.TreeNodes = this.treeViewGenerator.Generate();
        }

        public IEnumerable<IResult> CloseTabItem(ITabItemViewModel viewModel)
        {
            yield return new TabItemLoadingStateResult(viewModel.CurrentLoadingState)
                .WhenCancelled(() => new MessageBoxCancellationResult(dialogCoordinator,
                                                                      "Try again later :)", 
                                                                      "Tab is in progress.."));
            var tabItem = base.Items[this.selectedTabIndex];
            base.DeactivateItem(tabItem, true);
            this.tabItemGenerator.Release(tabItem);
        }

        public IEnumerable<IResult> CreateTabItem(TreeNodeModel treeNode)
        {
            yield return new TabItemMultiLoadResult(treeNode.Name, treeNode.CanOpenMultipleTabItems, base.Items)
                .WhenCancelled(() => new MessageBoxCancellationResult(dialogCoordinator, 
                                                                      "Multiple tabs from the selection are not allowed", 
                                                                      "Multiload not allowed"));
            
            var tabItem = this.tabItemGenerator.Create(treeNode.Name, false, treeNode.Icon);
            base.ActivateItem(tabItem);
            this.SelectedTabIndex = base.Items.Count - 1;
        }

        public async void OpenAbout()
        {
            var customDialog = new CustomDialog();
            var dataContext = new AboutViewModel(instance =>
            {
                this.dialogCoordinator.HideMetroDialogAsync(this, customDialog);
            });

            customDialog.Content = new AboutView() { DataContext = dataContext };
            await this.dialogCoordinator.ShowMetroDialogAsync(this, customDialog);
        }

        public override async void CanClose(Action<bool> callback)
        {
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Quit",
                NegativeButtonText = "Cancel",
                AnimateShow = true,
                AnimateHide = false
            };

            var result = await this.dialogCoordinator.
                ShowMessageAsync(this, "Quit application?",
                                 "Sure you want to quit application?",
                                 MessageDialogStyle.AffirmativeAndNegative, mySettings);

            var close = result == MessageDialogResult.Affirmative;

            callback(close);
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

        public ObservableCollection<TreeNodeModel> TreeNodes { get; set; }
    }
}