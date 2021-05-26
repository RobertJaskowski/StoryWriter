using MonkeyCache.FileStore;
using StoryWriter.PageModels.Base;
using StoryWriter.Services.Stories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace StoryWriter.PageModels
{
    class CreateStoryPageModel : PageModelBase
    {
        #region Properties

        private ObservableCollection<string> _errors;

        public ObservableCollection<string> Errors
        {
            get
            {
                if (_errors == null)
                    _errors = new ObservableCollection<string>();
                return _errors;
            }
            set
            {
                _errors = value;
                SetProperty(ref _errors, value);
            }
        }


        private bool _isInputValid;
        public bool IsInputValid
        {
            get { return _isInputValid; }
            set
            {
                _isInputValid = value;
                SetProperty(ref _isInputValid, value);

            }
        }

        private Color _currentValidationColor;

        public Color CurrentValidationColor
        {
            get { return _currentValidationColor; }
            set
            {
                _currentValidationColor = value;
                SetProperty(ref _currentValidationColor, value);
            }
        }



        private string _storyName;
        public string StoryName
        {
            get
            {
                //if (_storyName == null)
                //    _storyName = "";
                return _storyName;
            }
            set
            {
                _storyName = value;
                SetProperty(ref _storyName, value);

            }
        }


        private bool _isStoryNameValid;
        public bool IsStoryNameValid
        {
            get { return _isStoryNameValid; }
            set
            {
                _isStoryNameValid = value;
                SetProperty(ref _isStoryNameValid, value);

                OnValidationDataChanged();

            }
        }

        private List<object> _storyNameErrors;
        public List<object> StoryNameErrors
        {
            get
            {
                if (_storyNameErrors == null)
                    _storyNameErrors = new List<object>();
                return _storyNameErrors;
            }
            set
            {
                _storyNameErrors = value;
                SetProperty(ref _storyNameErrors, value);

                OnErrorsChanged();
            }
        }

        private void OnErrorsChanged()
        {
            var e = new List<string>();
            if (StoryNameErrors.Count > 0)
                foreach (var item in StoryNameErrors)
                {
                    if (item is string)
                        e.Add(item.ToString());
                }

            Errors = new ObservableCollection<string>(e);
        }


        private void OnValidationDataChanged()
        {
            if (IsStoryNameValid)
                IsInputValid = true;
            else
                IsInputValid = false;


            if (IsInputValid)
                CurrentValidationColor = Color.Green;
            else
                CurrentValidationColor = Color.Red;
        }

        #endregion


        #region Commands


        public Command BackButton { get; }
        public  Command CreateButton { get; }

        #endregion

        private INavigationService _navigationService;
        private IStoriesService _storiesService;
        private StoriesPageModel _storiesPM;

        public CreateStoryPageModel(INavigationService navigationService, IStoriesService storiesService, StoriesPageModel storiesPageModel)
        {
            _navigationService = navigationService;
            _storiesService = storiesService;
            _storiesPM = storiesPageModel;

            CreateButton = new Command(OnCreateStory, (e)=> { return IsInputValid; });
            BackButton = new Command(Back);
        }

        private void Back(object obj)
        {
            Application.Current.MainPage.SendBackButtonPressed();
        }

        private async void OnCreateStory(object obj)
        {
            await _storiesService.CreateStory(StoryName);
            await _navigationService.GoBackAsync();
            _storiesPM.MyTabTapped.Execute(null);

            
        }
    }
}
