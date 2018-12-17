using System;
using System.Linq;
using System.Windows;
using System.Reflection;
using System.Collections.Generic;

using Castle.Windsor;
using Caliburn.Micro;
using Castle.Windsor.Installer;

using TreeviewTabControlSkeleton.Ui.ViewModels;

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
            Container.Install(FromAssembly.This());
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
