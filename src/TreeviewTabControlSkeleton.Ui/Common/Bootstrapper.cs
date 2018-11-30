using Caliburn.Micro;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using TreeviewTabControlSkeleton.Ui.ViewModels;
using TreeviewTabControlSkeleton.Ui.Views;

namespace TreeviewTabControlSkeleton.Ui.Common
{
    public class Bootstrapper : BootstrapperBase
    {
        private static WindsorContainer container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new WindsorContainer();

            container.Register(Component.For<IWindowManager>().ImplementedBy<WindowManager>().LifeStyle.Is(LifestyleType.Singleton));
            container.Register(Component.For<ShellView>().ImplementedBy<ShellView>().LifeStyle.Is(LifestyleType.Singleton));
            container.Register(Component.For<ShellViewModel>().ImplementedBy<ShellViewModel>().LifeStyle.Is(LifestyleType.Singleton));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return String.IsNullOrWhiteSpace(key)
                ? container.Resolve(service)
                : container.Resolve(key, service);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            return container.ResolveAll(service) as IEnumerable<object>;
        }

        protected override void BuildUp(object instance)
        {
            /*
                [OPTIONAL] if you want property injection
             */
            var list = instance.GetType().GetProperties()
                .Where(property => property.CanWrite && property.PropertyType.IsPublic)
                .Where(property => container.Kernel.HasComponent(property.PropertyType));

            foreach (var propertyInfo in list)
            {
                propertyInfo.SetValue(instance, container.Resolve(propertyInfo.PropertyType), null);
            }
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[]
            {
                Assembly.GetExecutingAssembly(),
                Assembly.Load("TreeviewTabControlSkeleton.WpfInfrastructure")
            };
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            container.Dispose();
            base.OnExit(sender, e);
        }
    }
}
