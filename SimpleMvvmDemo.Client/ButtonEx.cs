using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleMvvmDemo.Client
{
    public class ButtonEx:DependencyObject
    {


        public static CornerRadius GetRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(RadiusProperty);
        }

        public static void SetRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(RadiusProperty, value);
        }

        // Using a DependencyProperty as the backing store for Radius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.RegisterAttached("Radius", typeof(CornerRadius), typeof(ButtonEx), new PropertyMetadata(null));



    }
}
