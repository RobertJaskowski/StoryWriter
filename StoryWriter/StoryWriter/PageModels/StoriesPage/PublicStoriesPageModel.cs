using StoryWriter.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoryWriter.PageModels.StoriesPage
{
    public class PublicStoriesPageModel : PageModelBase
    {
        private StoriesPageModel storiesPageModel;

        public PublicStoriesPageModel(StoriesPageModel storiesPageModel)
        {
            this.storiesPageModel = storiesPageModel;
        }
    }
}