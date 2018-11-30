using System;
using System.Threading;
using System.Windows;
using TreeviewTabControlSkeleton.Ui.Common;

namespace TreeviewTabControlSkeleton.Ui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Mutex mutex;

        public App()
        {
            this.Resources.Add("Bootstrapper", new Bootstrapper());

            mutex = new Mutex(true, "TreeviewTabControlSkeleton" + Environment.UserName, out var mutexNew);

            if (!mutexNew)
            {
                mutex.Dispose();
                throw new Exception("Mutex TreeviewTabControlSkeleton");

            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (mutex != null)
            {
                mutex.ReleaseMutex();
                mutex.Dispose();
                mutex = null;
            }

            base.OnExit(e);
        }
    }
}
