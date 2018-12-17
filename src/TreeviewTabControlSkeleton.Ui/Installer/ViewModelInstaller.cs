using Castle.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

namespace TreeviewTabControlSkeleton.Ui.Installer
{
    public class ViewModelInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                               .Pick().If(t => t.FindInterfaces((t1, o) => t1.Name == "ITabItemViewModel", null).Length > 0)
                               .Configure(c => c.LifeStyle.Is(LifestyleType.Transient)));

            container.Register(Classes.FromThisAssembly()
                               .Pick().If(t => t.FindInterfaces((t1, o) => t1.Name != "ITabItemViewModel", null).Length > 0)
                               .If(p => p.Name.EndsWith("ViewModel"))
                               .Configure(c => c.LifeStyle.Is(LifestyleType.Singleton)));
        }
    }
}