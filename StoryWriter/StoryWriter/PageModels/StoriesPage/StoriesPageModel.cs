using StoryWriter.Models;
using StoryWriter.PageModels.Base;
using StoryWriter.Services.Stories;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StoryWriter.PageModels
{
    public class StoriesPageModel : PageModelBase
    {
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

        private ObservableCollection<Story> _myStoriesList;

        public ObservableCollection<Story> MyStoriesList
        {
            get
            {
                if (_myStoriesList == null)
                {
                    _myStoriesList = new ObservableCollection<Story>();
                    //_storiesList.Add(new Story("test1"));
                }

                return _myStoriesList;
            }
            set
            {
                SetProperty(ref _myStoriesList, value);
            }
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
            MyStoriesList.Add(new Story() { Name = "asdfsadf" });
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

            var allMy = await _storiesService.GetAllFavorited();

            MyStoriesList = new ObservableCollection<Story>(allMy.ToList());
        }

        private async void OnAllTabTapped(object obj)
        {
            if (IsRefreshing) return;
            IsRefreshing = true;

            var allPublic = await _storiesService.GetAllPublic();
            if (allPublic.Count > 0)
                StoriesList = new ObservableCollection<Story>(allPublic.ToList());
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