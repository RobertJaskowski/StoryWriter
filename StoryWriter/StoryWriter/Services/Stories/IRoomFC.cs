using StoryWriter.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryWriter.Services.Stories
{
    public interface IRoomFC<T> : IFirebaseCollection<T>  where T: IIdentifiable
    {
        Task<IList<T>> GetAllPublic();

    }
}
