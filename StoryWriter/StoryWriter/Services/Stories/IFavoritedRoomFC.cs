using System;
using System.Collections.Generic;
using System.Text;

namespace StoryWriter.Services.Stories
{
    public interface IFavoritedRoomFC<T> : IFirebaseCollection<T> where T : IIdentifiable
    {

    }
}
