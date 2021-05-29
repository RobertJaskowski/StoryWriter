using StoryWriter.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoryWriter.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : TabbedPage
    {
        public static BindableProperty IsHiddenProperty = BindableProperty.Create("IsHidden", typeof(bool), typeof(DashboardPage), false, BindingMode.TwoWay);

        public bool IsHidden
        {
            set { base.SetValue(IsHiddenProperty, value); }
            get { return (bool)base.GetValue(IsHiddenProperty); }
        }

        public DashboardPage()
        {
            InitializeComponent();
        }
    }
}