using MonkeyCache.FileStore;
using MvvmHelpers;
using StoryWriter.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace StoryWriter.ViewModels
{
    class CreateStoryViewModel : BaseViewModel
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
                OnPropertyChanged();
            }
        }


        private bool _isInputValid;
        public bool IsInputValid
        {
            get { return _isInputValid; }
            set
            {
                _isInputValid = value;
                OnPropertyChanged();

            }
        }

        private Color _currentValidationColor;

        public Color CurrentValidationColor
        {
            get { return _currentValidationColor; }
            set
            {
                _currentValidationColor = value;
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }


        private bool _isStoryNameValid;
        public bool IsStoryNameValid
        {
            get { return _isStoryNameValid; }
            set
            {
                _isStoryNameValid = value;
                OnPropertyChanged();
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
                OnPropertyChanged();
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

        private Command _backButton;
        public Command BackButton
        {
            get
            {
                if (_backButton == null)
                {
                    _backButton = new Command(() =>
                    {
                        Application.Current.MainPage.SendBackButtonPressed();
                    });
                }

                return _backButton;
            }
        }

        private Command _createButton;
        public Command CreateButton
        {
            get
            {
                if (_createButton == null)
                {
                    _createButton = new Command(() =>
                    {
                        if (!IsInputValid) return;
                        
                        new Story(StoryName);
                    }, () =>
                    {

                        return IsInputValid;
                    });
                }

                return _createButton;
            }
        }
        #endregion


        public CreateStoryViewModel()
        {

        }
    }
}
