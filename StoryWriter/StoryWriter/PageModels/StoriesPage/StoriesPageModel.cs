using StoryWriter.Models;
using StoryWriter.PageModels.Base;
using StoryWriter.PageModels.StoriesPage;
using StoryWriter.Pages.StoriesPages;
using StoryWriter.Services.Stories;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StoryWriter.PageModels
{
    public class StoriesPageModel : PageModelBase
    {
        private MyStoriesPageModel _myStoriesPageModel;

        public MyStoriesPageModel MyStoriesPageModel
        {
            get => _myStoriesPageModel;
            set => SetProperty(ref _myStoriesPageModel, value);
        }

        private FavoritedStoriesPageModel _favoritedStoriesPageModel;

        public FavoritedStoriesPageModel FavoritedStoriesPageModel
        {
            get => _favoritedStoriesPageModel;
            set => SetProperty(ref _favoritedStoriesPageModel, value);
        }

        private PublicStoriesPageModel _publicStoriesPageModel;

        public PublicStoriesPageModel PublicStoriesPageModel
        {
            get => _publicStoriesPageModel;
            set => SetProperty(ref _publicStoriesPageModel, value);
        }

        private int _selectedTabViewIndex;

        public int SelectedTabViewIndex
        {
            get => _selectedTabViewIndex;
            set => SetProperty(ref _selectedTabViewIndex, value);
        }

        private bool _isRefreshing;

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        private ObservableCollection<Story> _storiesList;

        public ObservableCollection<Story> StoriesList
        {
            get
            {
                if (_storiesList == null)
                {
                    _storiesList = new ObservableCollection<Story>();
                }

                return _storiesList;
            }
            set
            {
                SetProperty(ref _storiesList, value);
            }
        }

        public ICommand RefreshCommand { get; }
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
        public INavigationService _navigationService;
        private IStoriesService _storiesService;

        public StoriesPageModel(INavigationService navigationService, IStoriesService storiesService)
        {
            _navigationService = navigationService;
            this._storiesService = storiesService;

            MyStoriesPageModel = new MyStoriesPageModel(this);
            FavoritedStoriesPageModel = new FavoritedStoriesPageModel(this);
            PublicStoriesPageModel = new PublicStoriesPageModel(this);

            AllTabTapped = new Command(OnAllTabTapped);
            MyTabTapped = new Command(OnMyTabTapped);
            CreateStoryButton = new Command(OnCreateStoryButtonClicked);
            RefreshCommand = new Command(OnRefresh);
        }

        private void OnRefresh(object obj)
        {
        }

        private void OnTestButtonClicked(object obj)
        {
            MyStoriesPageModel.MyStoriesList.Add(new Story() { Title = "asdfsadf" });
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
            if (IsRefreshing) return;
            IsRefreshing = true;

            MyStoriesPageModel.MyStoriesList = new ObservableCollection<Story>();
            var allMy = await _storiesService.GetAllFavorited();

            MyStoriesPageModel.MyStoriesList = new ObservableCollection<Story>(allMy.ToList());

            IsRefreshing = false;
        }

        private async void OnAllTabTapped(object obj)
        {
            if (IsRefreshing) return;
            IsRefreshing = true;

            var allPublic = await _storiesService.GetAllPublic();
            if (allPublic.Count > 0)
                StoriesList = new ObservableCollection<Story>(allPublic.ToList());

            IsRefreshing = false;
        }

        private async void OnCreateStoryButtonClicked()
        {
            await _navigationService.NavigateToAsync<CreateStoryPageModel>();
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await base.InitializeAsync(navigationData);
        }
    }
}