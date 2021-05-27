using StoryWriter.Models;
using StoryWriter.PageModels.Base;
using StoryWriter.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

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
    }
}