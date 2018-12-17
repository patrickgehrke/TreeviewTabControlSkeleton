using Castle.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

using MahApps.Metro.Controls.Dialogs;

namespace TreeviewTabControlSkeleton.Ui.Installer
{
    public class MahAppsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDialogCoordinator>().ImplementedBy<DialogCoordinator>().LifeStyle.Is(LifestyleType.Singleton));
        }
    }
}
