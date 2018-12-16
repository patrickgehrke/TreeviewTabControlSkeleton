using Caliburn.Micro;
using Castle.Core;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MahApps.Metro.Controls.Dialogs;
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
        public static WindsorContainer Container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            Container = new WindsorContainer();

            Container.Register(Component.For<IWindowManager>().ImplementedBy<WindowManager>().LifeStyle.Is(LifestyleType.Singleton));
            Container.Register(Component.For<ShellView>().ImplementedBy<ShellView>().LifeStyle.Is(LifestyleType.Singleton));
            Container.Register(Component.For<ShellViewModel>().ImplementedBy<ShellViewModel>().LifeStyle.Is(LifestyleType.Singleton));
            Container.Register(Component.For<DummyView>().ImplementedBy<DummyView>().LifeStyle.Is(LifestyleType.Transient));
            Container.Register(Component.For<DummyViewModel>().ImplementedBy<DummyViewModel>().LifeStyle.Is(LifestyleType.Transient));
            Container.Register(Component.For<ITabItemGenerator>().ImplementedBy<TabItemGenerator>().LifeStyle.Is(LifestyleType.Singleton));
            Container.Register(Component.For<IDialogCoordinator>().ImplementedBy<DialogCoordinator>().LifeStyle.Is(LifestyleType.Singleton));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return String.IsNullOrWhiteSpace(key)
                ? Container.Resolve(service)
                : Container.Resolve(key, service);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            return Container.ResolveAll(service) as IEnumerable<object>;
        }

        protected override void BuildUp(object instance)
        {
            /*
                [OPTIONAL] if you want property injection
             */
            var list = instance.GetType().GetProperties()
                .Where(property => property.CanWrite && property.PropertyType.IsPublic)
                .Where(property => Container.Kernel.HasComponent(property.PropertyType));

            foreach (var propertyInfo in list)
            {
                propertyInfo.SetValue(instance, Container.Resolve(propertyInfo.PropertyType), null);
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
            Container.Dispose();
            base.OnExit(sender, e);
        }
    }
}
