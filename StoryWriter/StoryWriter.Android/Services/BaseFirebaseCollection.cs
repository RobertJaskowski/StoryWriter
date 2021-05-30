using Firebase.Firestore;
using StoryWriter.Droid.Extensions;
using StoryWriter.Droid.ServiceListeners;
using StoryWriter.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryWriter.Droid.Services
{
    public abstract class BaseFirebaseCollection<T> : IFirebaseCollection<T> where T : IIdentifiable
    {
        public BaseFirebaseCollection()
        {
        }

        protected abstract string CollectionPath { get; }

        public Task<bool> Delete(T item)
        {
            var tcs = new TaskCompletionSource<bool>();

            FirebaseFirestore.Instance
                .Collection(CollectionPath)
                .Document(item.Id)
                .Delete()
                .AddOnCompleteListener(new OnDeleteCompleteListener(tcs));

            return tcs.Task;
        }

        public Task<T> Get(string id)
        {
            var tcs = new TaskCompletionSource<T>();

            FirebaseFirestore.Instance
                .Collection(CollectionPath)
                .Document(id)
                .Get()
                .AddOnCompleteListener(new OnDocumentCompleteListener<T>(tcs));

            return tcs.Task;
        }

        public Task<IList<T>> GetAll()
        {
            var tcs = new TaskCompletionSource<IList<T>>();

            FirebaseFirestore.Instance
                .Collection(CollectionPath)
                .Get()
                .AddOnCompleteListener(new OnCollectionCompleteListener<T>(tcs));

            return tcs.Task;
        }

        public Task<string> Save(T item)
        {
            var tcs = new TaskCompletionSource<string>();

            FirebaseFirestore.Instance
                .Collection(CollectionPath)
                .Add(item.ConvertToHashMap())
                .AddOnCompleteListener(new OnCreateCompleteListener(tcs));

            return tcs.Task;
        }

        public Task<bool> Update(T item)
        {
            var tcs = new TaskCompletionSource<bool>();

            FirebaseFirestore.Instance
                .Collection(CollectionPath)
                .Document(item.Id)
                .Update(item.ConvertToDictionary())
                .AddOnCompleteListener(new OnDocumentUpdateCompleteListener(tcs));

            return tcs.Task;
        }
    }
}