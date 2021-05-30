using StoryWriter.Models;
using StoryWriter.PageModels.Base;
using StoryWriter.Services;
using StoryWriter.Services.Stories;
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

        private Character _selectedCharacter;

        public Character SelectedCharacter
        {
            get => _selectedCharacter;
            set => SetProperty(ref _selectedCharacter, value);
        }

        private bool _isWritingEnabled;

        public bool IsWritingEnabled
        {
            get => _isWritingEnabled;
            set => SetProperty(ref _isWritingEnabled, value);
        }

        private string _currentMessage;
        private readonly INavigationService navigationService;
        private readonly IStoriesService storiesService;
        private readonly IAccountService accountService;

        public string CurrentMessage
        {
            get => _currentMessage;
            set => SetProperty(ref _currentMessage, value);
        }

        private bool IsCharacterSelected => SelectedCharacter != null;

        public ICommand SendMessage { get; }
        public ICommand EditStoryCommand { get; }
        public ICommand CharacterTappedCommand { get; }

        public StoryWritingRoomPageModel(INavigationService navigationService, IStoriesService storiesService, IAccountService accountService)
        {
            SendMessage = new Command(OnMessageSent);
            EditStoryCommand = new Command(OnEditStory);
            CharacterTappedCommand = new Command(OnCharacterTap);
            this.navigationService = navigationService;
            this.storiesService = storiesService;
            this.accountService = accountService;
        }

        private void OnCharacterTap(object obj)
        {
            if (obj is Character)
                SelectedCharacter = (Character)obj;
        }

        private async void OnEditStory(object obj)
        {
            await navigationService.NavigateToAsync<EditStoryPageModel>(CurrentStory);
        }

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData != null)
            {
                if (navigationData is Story story)
                {
                    CurrentStory = story;
                    IsWritingEnabled = true;
                }
            }

            return base.InitializeAsync(navigationData);
        }

        private async void OnMessageSent(object obj)
        {
            if (string.IsNullOrEmpty(CurrentMessage)) return;
            if (!IsCharacterSelected) return;

            IsWritingEnabled = false;

            var newDialogueLines = CurrentStory.DialogueLines;
            newDialogueLines.Add(new DialogueLine()
            {
                Character = SelectedCharacter,
                AuthorUser = await accountService.GetUserAsync(),
                Line = CurrentMessage
            });

            CurrentStory.DialogueLines = newDialogueLines;

            var res = await storiesService.UpdateStory(CurrentStory);

            if (res)
                CurrentMessage = "";

            IsWritingEnabled = true;
        }
    }
}