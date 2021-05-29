using StoryWriter.Models;
using StoryWriter.PageModels.Base;
using StoryWriter.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StoryWriter.PageModels.StoriesPage
{
    public class StoryWritingRoomPageModel : PageModelBase
    {
        public Story _currentStory;

        public Story CurrentStory
        {
            get => _currentStory;
            set => SetProperty(ref _currentStory, value);
        }

        private string _selectedCharacter;

        public string SelectedCharacter
        {
            get => _selectedCharacter;
            set => SetProperty(ref _selectedCharacter, value);
        }

        private string _currentMessage;

        public string CurrentMessage
        {
            get => _currentMessage;
            set => SetProperty(ref _currentMessage, value);
        }

        public ICommand SendMessage { get; }

        public StoryWritingRoomPageModel()
        {
            SendMessage = new Command(OnMessageSent);
        }

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData != null)
            {
                if (navigationData is Story story)
                {
                    CurrentStory = story;
                }
            }

            return base.InitializeAsync(navigationData);
        }

        private async void OnMessageSent(object obj)
        {
        }
    }
}