﻿using System;
using System.Threading.Tasks;
using Android.Gms.Tasks;
using Firebase.Firestore;
using StoryWriter.Droid.Extensions;
using StoryWriter.Services;
using Task = Android.Gms.Tasks.Task;

namespace StoryWriter.Droid.ServiceListeners
{
    public class OnDocumentCompleteListener<T> : Java.Lang.Object, IOnCompleteListener
        where T : IIdentifiable
    {
        private TaskCompletionSource<T> _tcs;

        public OnDocumentCompleteListener(TaskCompletionSource<T> tcs)
        {
            _tcs = tcs;
        }

        public void OnComplete(Task task)
        {
            if (task.IsSuccessful)
            {
                var docObj = task.Result;
                if (docObj is DocumentSnapshot docRef)
                {
                    _tcs.TrySetResult(docRef.Convert<T>());
                    return;
                }
            }
            // something went wrong
            _tcs.TrySetResult(default);
        }
    }
}
