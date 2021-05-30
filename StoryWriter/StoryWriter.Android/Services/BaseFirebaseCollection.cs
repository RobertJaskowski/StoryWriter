using Firebase.Firestore;
using Java.Util;
using Newtonsoft.Json;
using StoryWriter.Droid.Extensions;
using StoryWriter.Droid.ServiceListeners;
using StoryWriter.Models;
using StoryWriter.Services;
using System;
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
            //item.ConvertToDictionary()
            FirebaseFirestore.Instance
                .Collection(CollectionPath)
                .Document(item.Id)
                .Set(ConvertToHashMap(item))
                .AddOnCompleteListener(new OnDocumentUpdateCompleteListener(tcs));

            return tcs.Task;
        }

        public JavaStory ToStory(T item)
        {
            var ite = item as Story;

            var ret = new JavaStory(ite);
            return ret;
        }

        public static Dictionary<string, Java.Lang.Object> ConvertToDictionary(T item)
        {
            var dict = new Dictionary<string, Java.Lang.Object>();

            //dict.Add("Id", new Java.Lang.String(str);)

            var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            var propertyDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonStr);

            foreach (var key in propertyDict.Keys)
            {
                if (key.Equals("Id"))
                    continue;
                var val = propertyDict[key];
                Java.Lang.Object javaVal = null;
                if (val is string str)
                    javaVal = new Java.Lang.String(str);
                else if (val is double dbl)
                    javaVal = new Java.Lang.Double(dbl);
                else if (val is int intVal)
                    javaVal = new Java.Lang.Integer(intVal);
                else if (val is DateTime dt)
                    javaVal = dt.ToString();
                else if (val is bool boolVal)
                    javaVal = new Java.Lang.Boolean(boolVal);

                if (javaVal != null)
                    dict.Add(key, javaVal);
            }

            return dict;
        }

        public static HashMap ConvertToHashMap(T item)
        {
            return new HashMap(ConvertToDictionary(item));
        }
    }
}