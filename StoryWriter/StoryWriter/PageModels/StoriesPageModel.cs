using StoryWriter.Model;
using StoryWriter.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.Extensions;
using StoryWriter.PageModels.Base;
using Xamarin.Forms;
using StoryWriter.Pages;
using StoryWriter.Services;
using StoryWriter.Models;
using System.Threading.Tasks;

namespace StoryWriter.PageModels
{
    public class StoriesPageModel : PageModelBase
    {


        private List<Story> _storiesList;
        public List<Story> StoriesList
        {
            get
            {
                if (_storiesList == null)
                {
                    _storiesList = new List<Story>();
                    _storiesList.Add(new Story("test1"));
                }

                return _storiesList;
            }
            set
            {

                SetProperty(ref _storiesList, value);
            }
        }


        private Command _createStoryButton;
        public Command CreateStoryButton
        {
            get
            {
                if (_createStoryButton == null)
                {
                    _createStoryButton = new Command(OnTestButtonClicked/*OnCreateStoryButtonClicked*/);
                }

                return _createStoryButton;
            }
        }

        private Command _testButton;
        public Command TestButton
        {
            get
            {
                if (_testButton == null)
                {
                    _testButton = new Command(OnTestButtonClicked);
                }

                return _testButton;
            }
        }

        private void OnTestButtonClicked(object obj)
        {
            var result = PageModelLocator.Resolve<IFirebaseCollection<MyTestData>>().Save(new MyTestData
            {
                name = "nametest",
                flag = true
            });


            if (result != null)
            {

            }
        }

        void OnCreateStoryButtonClicked()
        {
            // Application.Current.MainPage.Navigation.ShowPopup(new CreateStoryPopup() { IsLightDismissEnabled = true });

            Application.Current.MainPage.Navigation.PushModalAsync(new CreateStoryPage());
        }

        public override async Task InitializeAsync(object navigationData)
        {
            

            await base.InitializeAsync(navigationData);
        }


    }


}
