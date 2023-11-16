using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace LazyApiPack.Wpf.Utils.Xaml
{
    public static class BindingHelper
    {
        public static BindingExpressionBase SetBinding(object sourceObject, string sourcePropertyName, DependencyObject targetObject,
                                                       DependencyProperty targetProperty, object fallbackValue = null, BindingMode? bindingMode = null,
                                                       Action<Binding> customizeBinding = null)
        {
            return SetBinding(sourceObject, sourcePropertyName, targetObject, targetProperty, null, null, null, bindingMode, fallbackValue, customizeBinding);
        }

        public static BindingExpressionBase SetBinding(object sourceObject, string sourcePropertyName, DependencyObject targetObject,
                                                       DependencyProperty targetProperty, IValueConverter converter, object converterParameter = null,
                                                       CultureInfo converterCulture = null, BindingMode? bindingMode = null, object fallbackValue = null,
                                                       Action<Binding> customizeBinding = null)
        {
            var lcBinding = new Binding();
            lcBinding.Path = new PropertyPath(sourcePropertyName);
            lcBinding.Source = sourceObject;
            if (bindingMode != null)
            {
                lcBinding.Mode = bindingMode.Value;
            }

            if (converter != null)
            {
                lcBinding.Converter = converter;
                lcBinding.ConverterParameter = converterParameter;
                if (converterCulture != null)
                {
                    lcBinding.ConverterCulture = converterCulture;
                }

            }

            lcBinding.FallbackValue = fallbackValue;
            customizeBinding?.Invoke(lcBinding);
            return BindingOperations.SetBinding(targetObject, targetProperty, lcBinding);

        }
    }
}
