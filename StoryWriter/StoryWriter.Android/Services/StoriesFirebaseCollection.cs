using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Firestore;
using StoryWriter.Droid.ServiceListeners;
using StoryWriter.Droid.Services;
using StoryWriter.Models;
using StoryWriter.Services;
using StoryWriter.Services.Stories;
using Xamarin.Forms;

[assembly: Dependency(typeof(StoriesFirebaseCollection<Story>))]
namespace StoryWriter.Droid.Services
{
    public class StoriesFirebaseCollection<T> : BaseFirebaseCollection<T>, IRoomFC<T> where T : IIdentifiable
    {
        protected override string DocumentPath =>
            "rooms/";


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