using Caliburn.Micro;
using TreeviewTabControlSkeleton.Ui.Common;
using TreeviewTabControlSkeleton.WpfInfrastructure.Enums;

namespace TreeviewTabControlSkeleton.Ui.Coroutines.TabItem
{
    public class TabItemLoadingStateResult : ResultBase
    {
        private readonly LoadingState loadingState;

        public TabItemLoadingStateResult(LoadingState loadingState)
        {
            this.loadingState = loadingState;
        }

        public override void Execute(CoroutineExecutionContext context)
        {
            if (loadingState == LoadingState.Indeterminate)
                OnCancelled();
            else OnCompleted(new ResultCompletionEventArgs());
        }
    }
}
