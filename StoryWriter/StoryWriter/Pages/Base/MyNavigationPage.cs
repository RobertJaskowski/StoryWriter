using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StoryWriter.Pages.Base
{
    [Obsolete("setvalue doesnt work")]
    public class MyNavigationPage : NavigationPage
    {
        public MyNavigationPage()
        {
        }

        public MyNavigationPage(Page root) : base(root)
        {
            Pushed += MyNavigationPage_Pushed;
            Popped += MyNavigationPage_Popped;
        }

        private void MyNavigationPage_Popped(object sender, NavigationEventArgs e)
        {
            if (CurrentPage == RootPage)
            {
                var mainPage = App.Current.MainPage as DashboardPage;
                mainPage.IsHidden = false;
            }
        }

        private void MyNavigationPage_Pushed(object sender, NavigationEventArgs e)
        {
            DashboardPage mainPage = App.Current.MainPage as DashboardPage;
            mainPage.IsHidden = true;
        }
    }
}