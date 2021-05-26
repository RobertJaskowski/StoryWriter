using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Firestore;
using StoryWriter.Droid.ServiceListeners;
using StoryWriter.Droid.Services;
using StoryWriter.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(StoriesFirebaseCollection<Story>))]
namespace StoryWriter.Droid.Services
{
    public class StoriesFirebaseCollection<T> : BaseFirebaseCollection<T> where T : Story
    {
        protected override string DocumentPath =>
            "rooms/";


        public Task<IList<T>> GetAllPublic()
        {
            var tcs = new TaskCompletionSource<IList<T>>();
            var list = new List<T>();

            FirebaseFirestore.Instance
                .Collection(DocumentPath)
                .WhereEqualTo("IsPublic", true)
                .Get()
                .AddOnCompleteListener(new OnCollectionCompleteListener<T>(tcs));

            return tcs.Task;
        }



    }
}