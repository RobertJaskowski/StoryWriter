using Android.Content;
using Android.Views;
using CustomTabbedPageDemo.Droid;
using Google.Android.Material.Tabs;
using StoryWriter.Pages;
using StoryWriter.Pages.Base;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(DashboardPage), typeof(TabbedRenderer))]

namespace CustomTabbedPageDemo.Droid
{
    public class TabbedRenderer : TabbedPageRenderer
    {
        public TabbedRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "IsHidden")
            {
                TabLayout TabsLayout = null;
                for (int i = 0; i < ChildCount; ++i)
                {
                    Android.Views.View view = (Android.Views.View)GetChildAt(i);
                    if (view is TabLayout)
                        TabsLayout = (TabLayout)view;
                }
                if ((Element as DashboardPage).IsHidden)
                {
                    TabsLayout.Visibility = ViewStates.Invisible;
                }
                else
                {
                    TabsLayout.Visibility = ViewStates.Visible;
                }
            }
        }
    }
}