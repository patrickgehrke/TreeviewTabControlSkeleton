using System;
using System.Windows.Media;
using System.Collections.Generic;

using Castle.MicroKernel;
using TreeviewTabControlSkeleton.Ui.ViewModels;
using TreeviewTabControlSkeleton.WpfInfrastructure.ViewModels;

namespace TreeviewTabControlSkeleton.Ui.Common
{
    public class TabItemGenerator : ITabItemGenerator
    {
        private Dictionary<string, Type> viewModelTypeMapping;

        public TabItemGenerator()
        {
            this.viewModelTypeMapping = new Dictionary<string, Type>();
            SetupViewModelTypeMapping();
        }

        public ViewModelBase Create(string name, bool allowMultiLoad, PathGeometry icon)
        {
            return (ViewModelBase)Bootstrapper.Container.Resolve(this.viewModelTypeMapping[name],
                                                         new Arguments( new { name, allowMultiLoad, icon}));
        }

        public void Release(object viewModel)
        {
            Bootstrapper.Container.Release(viewModel);
        }

        private void SetupViewModelTypeMapping()
        {
            this.viewModelTypeMapping.Add("Dummy", typeof(DummyViewModel));
        }

    }

    public interface ITabItemGenerator
    {
        ViewModelBase Create(string name, bool allowMultiLoad, PathGeometry icon);

        void Release(object viewModel);
    }
}
