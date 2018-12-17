using Castle.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

using TreeviewTabControlSkeleton.Ui.Common;

namespace TreeviewTabControlSkeleton.Ui.Installer
{
    public class GeneratorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ITabItemGenerator>().ImplementedBy<TabItemGenerator>().LifeStyle.Is(LifestyleType.Singleton));
        }
    }
}
