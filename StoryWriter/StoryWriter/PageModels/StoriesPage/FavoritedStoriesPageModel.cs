using StoryWriter.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoryWriter.PageModels.StoriesPage
{
    public class FavoritedStoriesPageModel : PageModelBase
    {
        private StoriesPageModel storiesPageModel;

        public FavoritedStoriesPageModel(StoriesPageModel storiesPageModel)
        {
            this.storiesPageModel = storiesPageModel;
        }
    }
}