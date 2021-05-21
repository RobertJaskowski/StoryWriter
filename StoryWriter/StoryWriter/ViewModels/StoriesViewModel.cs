using MvvmHelpers;
using MvvmHelpers.Commands;
using StoryWriter.Model;
using StoryWriter.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace StoryWriter.ViewModels
{
    public class StoriesViewModel : BaseViewModel
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
                    _createStoryButton = new Command(OnCreateStoryButtonClicked);
                }

                return _createStoryButton;
            }
        }

        void OnCreateStoryButtonClicked()
        {
            // Application.Current.MainPage.Navigation.ShowPopup(new CreateStoryPopup() { IsLightDismissEnabled = true });

            Application.Current.MainPage.Navigation.PushModalAsync(new CreateStoryPage());
        }


    }


}
