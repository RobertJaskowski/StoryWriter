using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StoryWriter.Models;

namespace StoryWriter.Services.Stories
{
    public class StoriesService : IStoriesService
    {
        private readonly IRoomFC<Story> _roomFC;


        public StoriesService(IRoomFC<Story> firebaseCollection)
        {
            this._roomFC = firebaseCollection;
        }

        private void OnTaskCompleted(Task task, TaskCompletionSource<bool> tcs)
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                // something went wrong
                tcs.SetResult(false);
                return;
            }
            tcs.SetResult(true);
        }

        public Task<bool> CreateStory(string storyName)
        {
            var tcs = new TaskCompletionSource<bool>();
            _roomFC.Save(new Story() { Name = storyName }).ContinueWith((task) => OnTaskCompleted(task, tcs));
            return tcs.Task;
        }

        public Task<IList<Story>> GetAllPublic()
        {
            var tcs = new TaskCompletionSource<IList<Story>>();
            
            return tcs.Task;
        }

        public Task<IList<Story>> GetAllMy()
        {
            var tcs = new TaskCompletionSource<IList<Story>>();

            return tcs.Task;
        }
    }
}
