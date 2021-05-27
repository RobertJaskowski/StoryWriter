using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoryWriter.Pages.StoriesPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyStoriesPage : ContentView
    {
        public MyStoriesPage()
        {
            InitializeComponent();
        }
    }
}