using System;
using Caliburn.Micro;

namespace TreeviewTabControlSkeleton.Ui.Coroutines
{
    public abstract class ResultBase : IResult
    {
        public event EventHandler<ResultCompletionEventArgs> Completed;

        public abstract void Execute(CoroutineExecutionContext context);

        protected virtual void OnCompleted()
        {
            OnCompleted(new ResultCompletionEventArgs());
        }

        protected virtual void OnError(Exception error, bool wasCancelled)
        {
            OnCompleted(new ResultCompletionEventArgs
            {
                Error = error,
                WasCancelled = wasCancelled
            });
        }

        protected virtual void OnCancelled()
        {
            OnCompleted(new ResultCompletionEventArgs
            {
                WasCancelled = true
            });
        }

        protected virtual void OnCompleted(ResultCompletionEventArgs e)
        {
            Caliburn.Micro.Execute.OnUIThread(() => Completed(this, e));
        }
    }
}
