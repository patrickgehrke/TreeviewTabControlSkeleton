using System;
using System.Windows;
using System.Windows.Media;

namespace TreeviewTabControlSkeleton.WpfInfrastructure.Logos
{
    public partial class LogoResources
    {
        public static ResourceDictionary ResourceDictionary { get; }

        static LogoResources()
        {
            var source = new Uri("/TreeviewTabControlSkeleton.WpfInfrastructure;component/Logos/LogoResources.xaml", UriKind.Relative);
            ResourceDictionary = SharedResourceDictionary.GetSharedResourceDictionary(source);
        }

        public static PathGeometry Database
        {
            get { return GetLogoGeometry("ScaleIconDatabase"); }
        }

        public static PathGeometry PlayerProfile
        {
            get { return GetLogoGeometry("ScaleIconPlayerProfile"); }
        }

        public static PathGeometry Github
        {
            get { return GetLogoGeometry("ScaleIconGithub"); }
        }
        

        private static PathGeometry GetLogoGeometry(string rescourceKey)
        {
            return (PathGeometry)ResourceDictionary[rescourceKey];
        }
    }
}
