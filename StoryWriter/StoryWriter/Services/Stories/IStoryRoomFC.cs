using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryWriter.Services.Stories
{
    public interface IStoryRoomFC<T> : IFirebaseCollection<T> where T : IIdentifiable
    {
        Task<IList<T>> GetAllPublic();
    }
}