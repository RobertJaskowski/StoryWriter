using System;
using System.Collections.Generic;
using System.Text;

namespace StoryWriter.Services.Stories
{
    public interface IStoryWritingRoomDialogueLinesFC<T> : IFirebaseCollection<T> where T : IIdentifiable
    {
    }
}