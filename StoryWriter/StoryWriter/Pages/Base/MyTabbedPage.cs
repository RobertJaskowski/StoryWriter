using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StoryWriter.Pages.Base
{
    [Obsolete("setvalue doesnt work")]

    public class MyTabbedPage : TabbedPage
    {
        public static BindableProperty IsHiddenProperty = BindableProperty.Create("IsHidden", typeof(bool), typeof(MyTabbedPage), false, BindingMode.TwoWay, propertyChanged: IsHiddenPropertyChanged
            );
        [Obsolete("this too is not called idk")]
        private static void IsHiddenPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MyTabbedPage)bindable;
            control.IsHidden = (bool)newValue;
        }

        public bool IsHidden
        {
            set { base.SetValue(IsHiddenProperty, value); }
            get { return (bool)base.GetValue(IsHiddenProperty); }
        }
    }
}