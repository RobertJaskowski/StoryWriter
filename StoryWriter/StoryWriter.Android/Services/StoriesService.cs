using StoryWriter.Droid.Services;
using StoryWriter.Models;
using StoryWriter.Services.Stories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(StoriesService))]

namespace StoryWriter.Droid.Services
{
    public class StoriesService : IStoriesService
    {
        private readonly IStoryRoomFC<Story> _roomFC;
        private readonly IFavoritedRoomFC<FavoritedRoom> _favRoomFC;

        public StoriesService()
        {
            _roomFC = new StoryRoomFirebaseCollection<Story>();
            _favRoomFC = new FavoritedRoomFirebaseCollection<FavoritedRoom>();
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

        public async Task<bool> CreateStory(string storyName, bool isStoryPublic)
        {
            string stringID = "";

            var tcs = new TaskCompletionSource<bool>();
            await _roomFC.Save(new Story()
            {
                Name = storyName,
                IsPublic = isStoryPublic
            })
                .ContinueWith((task) => stringID = task.Result)
                .ContinueWith((task) => OnTaskCompleted(task, tcs));

            if (string.IsNullOrEmpty(stringID))
            {
                tcs.SetResult(false);
                return tcs.Task.Result;
            }

            await _favRoomFC.Save(new FavoritedRoom()
            {
                FavoritedRoomId = stringID,
            });
            //.ContinueWith((task) => OnTaskCompleted(task, tcs));

            return tcs.Task.Result;
        }

        public Task<IList<Story>> GetAllPublic()
        {
            return _roomFC.GetAllPublic();
        }

        public async Task<IList<Story>> GetAllFavorited()
        {
            var tcs = new TaskCompletionSource<IList<Story>>();
            IList<Story> returnStories = new List<Story>();

            //get users/id/rooms/favoritedRoom
            var r = await _favRoomFC.GetAll();

            if (r.Count > 0)
            {
                foreach (var fav in r)
                {
                    var fetchedRoom = await _roomFC.Get(fav.FavoritedRoomId);
                    returnStories.Add(fetchedRoom);
                }
            }

            tcs.TrySetResult(returnStories);

            return tcs.Task.Result;
        }
    }
}