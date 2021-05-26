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
using StoryWriter.Services.Stories;
using System.Windows.Input;

namespace StoryWriter.PageModels
{
    public class StoriesPageModel : PageModelBase
    {
        private List<Story> _myStoriesList;
        public List<Story> MyStoriesList
        {
            get
            {
                if (_myStoriesList == null)
                {
                    _myStoriesList = new List<Story>();
                    //_storiesList.Add(new Story("test1"));
                }

                return _myStoriesList;
            }
            set
            {

                SetProperty(ref _storiesList, value);
            }
        }

        private List<Story> _storiesList;
        public List<Story> StoriesList
        {
            get
            {
                if (_storiesList == null)
                {
                    _storiesList = new List<Story>();
                }

                return _storiesList;
            }
            set
            {

                SetProperty(ref _storiesList, value);
            }
        }


        public ICommand CreateStoryButton { get; }
        public ICommand MyTabTapped { get; }
        public ICommand AllTabTapped { get; }
        public ICommand TestButton
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


        private Command _testButton;
        private INavigationService _navigationService;
        private IStoriesService _storiesService;

        public StoriesPageModel(INavigationService navigationService, IStoriesService storiesService)
        {
            _navigationService = navigationService;
            this._storiesService = storiesService;


            AllTabTapped = new Command(OnAllTabTapped);
            MyTabTapped = new Command(OnMyTabTapped);
            CreateStoryButton = new Command(OnCreateStoryButtonClicked);

        }

        private void OnTestButtonClicked(object obj)
        {
            //var result = PageModelLocator.Resolve<IFirebaseCollection<MyTestData>>().Save(new MyTestData
            //{
            //    name = "nametest",
            //    flag = true
            //});


            //if (result != null)
            //{

            //}
        }

        private async void OnMyTabTapped(object obj)
        {
            var allMy = await _storiesService.GetAllFavorited();
            MyStoriesList = (List<Story>)allMy;
        }

        private async void OnAllTabTapped(object obj)
        {
            var allPublic = await _storiesService.GetAllPublic();
            if (allPublic.Count > 0)
                StoriesList = (List<Story>)allPublic;

        }

        async void OnCreateStoryButtonClicked()
        {
            await _navigationService.NavigateToAsync<CreateStoryPageModel>();
        }

        public override async Task InitializeAsync(object navigationData)
        {


            await base.InitializeAsync(navigationData);
        }


    }


}
