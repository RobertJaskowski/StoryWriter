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

        protected abstract string DocumentPath { get; }

        public Task<bool> Delete(T item)
        {
            var tcs = new TaskCompletionSource<bool>();

            FirebaseFirestore.Instance
                .Collection(DocumentPath)
                .Document(item.Id)
                .Delete()
                .AddOnCompleteListener(new OnDeleteCompleteListener(tcs));

            return tcs.Task;
        }

        public Task<T> Get(string id)
        {
            var tcs = new TaskCompletionSource<T>();

            FirebaseFirestore.Instance
                .Collection(DocumentPath)
                .Document(id)
                .Get()
                .AddOnCompleteListener(new OnDocumentCompleteListener<T>(tcs));

            return tcs.Task;
        }

        public Task<IList<T>> GetAll()
        {
            var tcs = new TaskCompletionSource<IList<T>>();

            FirebaseFirestore.Instance
                .Collection(DocumentPath)
                .Get()
                .AddOnCompleteListener(new OnCollectionCompleteListener<T>(tcs));

            return tcs.Task;
        }

        public Task<string> Save(T item)
        {
            var tcs = new TaskCompletionSource<string>();

            FirebaseFirestore.Instance
                .Collection(DocumentPath)
                .Add(item.ConvertToHashMap())
                .AddOnCompleteListener(new OnCreateCompleteListener(tcs));

            return tcs.Task;
        }
    }
}