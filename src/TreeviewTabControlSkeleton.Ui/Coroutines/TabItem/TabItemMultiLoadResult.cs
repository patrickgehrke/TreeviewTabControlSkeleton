using System.Linq;
using System.Collections.Generic;
using Caliburn.Micro;
using TreeviewTabControlSkeleton.Ui.Common;

namespace TreeviewTabControlSkeleton.Ui.Coroutines.TabItem
{
    public class TabItemMultiLoadResult : ResultBase
    {
        private string name;
        private bool canOpenMultipleTabItems;
        private readonly IList<IScreen> openTabs;

        public TabItemMultiLoadResult(string name, bool canOpenMultipleTabItems, IList<IScreen> openTabs)
        {
            this.name = name;
            this.openTabs = openTabs;
            this.canOpenMultipleTabItems = canOpenMultipleTabItems;
        }

        public override void Execute(CoroutineExecutionContext context)
        {
            var equalTabs = openTabs.Where(x => x.DisplayName == this.name).ToList();
            if(equalTabs.Count == 0 || equalTabs.Count >= 1 && this.canOpenMultipleTabItems)
                OnCompleted(new ResultCompletionEventArgs());
            else OnCancelled();
        }
    }
}
