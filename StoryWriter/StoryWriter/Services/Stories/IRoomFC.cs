using StoryWriter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoryWriter.Services.Stories
{
    public interface IRoomFC<T> : IFirebaseCollection<T> where T : Story
    {

    }
}
