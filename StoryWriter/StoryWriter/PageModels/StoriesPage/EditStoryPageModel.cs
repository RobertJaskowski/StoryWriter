using StoryWriter.Models;
using StoryWriter.PageModels.Base;
using StoryWriter.Services;
using StoryWriter.Services.Stories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StoryWriter.PageModels.StoriesPage
{
    public class EditStoryPageModel : PageModelBase
    {
        private Story _currentStory;

        public Story CurrentStory
        {
            get => _currentStory;
            set => SetProperty(ref _currentStory, value);
        }

        private Story _newStory;

        public Story NewStory
        {
            get => _newStory;
            set => SetProperty(ref _newStory, value);
        }

        private string _newCharacterEntry;

        public string NewCharacterEntry
        {
            get => _newCharacterEntry;
            set => SetProperty(ref _newCharacterEntry, value);
        }

        private bool _isFree;

        public bool IsFree
        {
            get => _isFree;
            set => SetProperty(ref _isFree, value);
        }

        private string _updatingFeedback;

        public string UpdatingFeedback
        {
            get
            {
                return _updatingFeedback;
            }
            set => SetProperty(ref _updatingFeedback, value);
        }

        private bool _isAdmin;

        public bool IsAdmin
        {
            get => _isAdmin;
            set => SetProperty(ref _isAdmin, value);
        }

        private string _isAdminFeedback;

        public string IsAdminFeedback
        {
            get => _isAdminFeedback;
            set
            {
                if (IsAdmin)
                {
                    value = "You are admin of this story";
                }
                else
                {
                    value = "You are not the admin of this story";
                }

                SetProperty(ref _isAdminFeedback, value);
            }
        }

        public ICommand CharacterRemoveCommand { get; }
        public ICommand CharacterTappedCommand { get; }
        public ICommand AddCharacterCommand { get; }
        public ICommand AcceptChangesCommand { get; }
        private readonly StoryWritingRoomPageModel storyWritingRoomPageModel;
        private readonly INavigationService navigationService;
        private readonly IStoriesService storiesService;
        private readonly IMessageService messageService;
        private readonly IAccountService accountService;

        public EditStoryPageModel(StoryWritingRoomPageModel storyWritingRoomPageModel, INavigationService navigationService, IStoriesService storiesService, IMessageService messageService, IAccountService accountService)
        {
            CharacterRemoveCommand = new Command(OnCharacterRemoved);
            CharacterTappedCommand = new Command(OnCharacterTapped);
            AddCharacterCommand = new Command(OnCharacterAdd);
            AcceptChangesCommand = new Command(OnAcceptChanges);
            this.storyWritingRoomPageModel = storyWritingRoomPageModel;
            this.navigationService = navigationService;
            this.storiesService = storiesService;
            this.messageService = messageService;
            this.accountService = accountService;
        }

        private async void OnAcceptChanges(object obj)
        {
            IsFree = false;

            storyWritingRoomPageModel.CurrentStory = NewStory;

            var res = await storiesService.UpdateStory(storyWritingRoomPageModel.CurrentStory);

            string shownMessage = res ? "Success" : "Fail";

            messageService.LongAlert(shownMessage);

            IsFree = true;

            if (res)
            {
                await navigationService.GoBackAsync();
                storyWritingRoomPageModel.CurrentStory = NewStory;
            }
        }

        private async void OnCharacterAdd(object obj)
        {
            if (string.IsNullOrEmpty(NewCharacterEntry)) return;
            IsFree = false;

            var res = await accountService.GetUserAsync();

            var c = NewStory.Copy();

            if (c.Characters == null)
                c.Characters = new List<Character>();
            c.Characters.Add(new Character()
            {
                Name = NewCharacterEntry,
                AuthorUser = res
            });
            NewCharacterEntry = "";

            NewStory = c;

            OnPropertyChanged(nameof(NewStory));

            IsFree = true;
        }

        private void OnCharacterTapped(object obj)
        {
        }

        private void OnCharacterRemoved(object obj)
        {
            if (obj != null && !(obj is Character)) return;
            var cha = obj as Character;

            var c = NewStory.Copy();

            Character re = null;
            foreach (var item in c.Characters)
            {
                if (item.Id == cha.Id)
                {
                    re = item;
                    break;
                }
            }
            if (re == null) return;

            c.Characters.Remove(re);

            NewStory = c;
            OnPropertyChanged(nameof(NewStory));
            OnPropertyChanged(nameof(NewStory.Characters));
        }

        public override async Task InitializeAsync(object navigationData)
        {
            CurrentStory = (Story)navigationData;

            NewStory = CurrentStory.Copy();

            IsFree = true;

            UpdatingFeedback = "Accept ";

            var res = await accountService.GetUserAsync();
            if (res.Id == NewStory.AdminId)
            {
                IsAdmin = true;
                IsAdminFeedback = "Is admin!";
            }
            await base.InitializeAsync(navigationData);
        }
    }
}