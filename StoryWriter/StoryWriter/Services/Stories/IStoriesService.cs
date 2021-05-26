using StoryWriter.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryWriter.Services.Stories
{
    public interface IStoriesService
    {
        Task<bool> CreateStory(string storyName);
        Task<IList<Story>> GetAllPublic();
        Task<IList<Story>> GetAllMy();
    }
}
