using Firebase.Firestore;
using StoryWriter.Droid.ServiceListeners;
using StoryWriter.Droid.Services;
using StoryWriter.Models;
using StoryWriter.Services;
using StoryWriter.Services.Stories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(StoryRoomFirebaseCollection<Story>))]

namespace StoryWriter.Droid.Services
{
    public class StoryRoomFirebaseCollection<T> : BaseFirebaseCollection<T>, IStoryRoomFC<T> where T : IIdentifiable
    {
        protected override string DocumentPath =>
            "stories/";

        public Task<IList<T>> GetAllPublic()
        {
            var tcs = new TaskCompletionSource<IList<T>>();

            FirebaseFirestore.Instance
                .Collection(DocumentPath)
                .WhereEqualTo("IsPublic", true)
                .Get()
                .AddOnCompleteListener(new OnCollectionCompleteListener<T>(tcs));

            return tcs.Task;
        }
    }
}