using Castle.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;

namespace TreeviewTabControlSkeleton.Ui.Installer
{
    public class ViewInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                               .Where(type => type.Name.EndsWith("View"))
                               .Configure(c => c.LifeStyle.Is(LifestyleType.Singleton)));
        }
    }
}
