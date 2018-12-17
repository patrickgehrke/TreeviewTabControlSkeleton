using Castle.Core;
using Castle.Windsor;
using Caliburn.Micro;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

namespace TreeviewTabControlSkeleton.Ui.Installer
{
    public class CaliburnMicroInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IWindowManager>().ImplementedBy<WindowManager>().LifeStyle.Is(LifestyleType.Singleton));
            container.Register(Component.For<IEventAggregator>().ImplementedBy<EventAggregator>().LifeStyle.Is(LifestyleType.Singleton));
        }
    }
}