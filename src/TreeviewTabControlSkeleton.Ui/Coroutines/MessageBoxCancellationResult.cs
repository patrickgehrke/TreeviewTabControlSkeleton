using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;
using TreeviewTabControlSkeleton.Ui.Common;

namespace TreeviewTabControlSkeleton.Ui.Coroutines
{
    public class MessageBoxCancellationResult : ResultBase
    {
        private readonly string title;
        private readonly string content;
        private readonly IDialogCoordinator dialogCoordinator;

        public MessageBoxCancellationResult(IDialogCoordinator dialogCoordinator, string content, string title)
        {
            this.title = title;
            this.content = content;
            this.dialogCoordinator = dialogCoordinator;
        }

        public override void Execute(CoroutineExecutionContext context)
        {
            MetroDialogSettings mds = new MetroDialogSettings() { AnimateShow = false, AnimateHide = false };
            this.dialogCoordinator.ShowMessageAsync(context.Target, title, content, MessageDialogStyle.Affirmative, mds);
            OnCancelled();
        }
    }
}
