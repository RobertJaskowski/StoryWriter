using StoryWriter.PageModels.Base;
using StoryWriter.PageModels.StoriesPage;
using System;
using System.Threading.Tasks;

namespace StoryWriter.PageModels
{
    public class DashboardPageModel : PageModelBase
    {
        private bool _isVisible;

        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }

        private StoriesPageModel _storiesPage;

        public StoriesPageModel StoriesPageModel
        {
            get => _storiesPage;
            set => SetProperty(ref _storiesPage, value);
        }

        private StoryWritingRoomPageModel _storyWritingPage;
        private readonly INavigationService _navigationService;

        public StoryWritingRoomPageModel StoryWritingRoomPageModel
        {
            get => _storyWritingPage;
            set => SetProperty(ref _storyWritingPage, value);
        }

        //private SummaryPageModel _summaryPM;

        //public SummaryPageModel SummaryPageModel
        //{
        //    get => _summaryPM;
        //    set => SetProperty(ref _summaryPM, value);
        //}

        private ProfilePageModel _profilePM;

        public ProfilePageModel ProfilePageModel
        {
            get => _profilePM;
            set => SetProperty(ref _profilePM, value);
        }

        //private SettingsPageModel _settigsPM;

        //public SettingsPageModel SettingsPageModel
        //{
        //    get => _settigsPM;
        //    set => SetProperty(ref _settigsPM, value);
        //}

        //private TimeClockPageModel _timeclockPM;

        //public TimeClockPageModel TimeClockPageModel
        //{
        //    get => _timeclockPM;
        //    set => SetProperty(ref _timeclockPM, value);
        //}

        public DashboardPageModel(
            INavigationService navigationService,
            ProfilePageModel profilePM,
            //SettingsPageModel settingsPM,
            StoriesPageModel storiesPM,
            StoryWritingRoomPageModel storyWritingPM
            )
        {
            this._navigationService = navigationService;
            ProfilePageModel = profilePM;
            //SettingsPageModel = settingsPM;
            StoriesPageModel = storiesPM;
            StoryWritingRoomPageModel = storyWritingPM;

            navigationService.OnPageSwitched += OnPageSwitched;
        }

        private void OnPageSwitched(PageModelBase newPageModel)
        {
            if (newPageModel is StoryWritingRoomPageModel)
                IsVisible = false;
            else
                IsVisible = true;
        }

        public override Task InitializeAsync(object navigationData)
        {
            return Task.WhenAny(
                base.InitializeAsync(navigationData),
                //ProfilePageModel.InitializeAsync(null),
                //SettingsPageModel.InitializeAsync(null),
                StoryWritingRoomPageModel.InitializeAsync(null),
                StoriesPageModel.InitializeAsync(null));
        }
    }
}