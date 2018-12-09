using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using TreeviewTabControlSkeleton.WpfInfrastructure.Enums;

namespace TreeviewTabControlSkeleton.WpfInfrastructure.Converter
{
    public class LoadingStateToVisibleConverter : IValueConverter
    {
        public bool Inverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var loadingState = (LoadingState)value;

            if (this.Inverted)
            {
                if (loadingState == LoadingState.None)
                {
                    return Visibility.Visible;
                }

                return Visibility.Hidden;
            }

            if (loadingState == LoadingState.None)
            {
                return Visibility.Hidden;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
