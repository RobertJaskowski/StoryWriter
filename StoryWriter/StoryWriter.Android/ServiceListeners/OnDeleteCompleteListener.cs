﻿using System;
using System.Threading.Tasks;
using Android.Gms.Tasks;
using Task = Android.Gms.Tasks.Task;

namespace StoryWriter.Droid.ServiceListeners
{
    public class OnDeleteCompleteListener : Java.Lang.Object, IOnCompleteListener
    {
        private TaskCompletionSource<bool> _tcs;

        public OnDeleteCompleteListener(TaskCompletionSource<bool> tcs)
        {
            _tcs = tcs;
        }

        public void OnComplete(Task task)
        {
            _tcs.TrySetResult(task.IsSuccessful);
        }
    }
}
