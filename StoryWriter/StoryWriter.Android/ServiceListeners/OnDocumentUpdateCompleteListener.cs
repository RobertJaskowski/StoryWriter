using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryWriter.Droid.ServiceListeners
{
    public class OnDocumentUpdateCompleteListener : Java.Lang.Object, IOnCompleteListener
    {
        private TaskCompletionSource<bool> _tcs;

        public OnDocumentUpdateCompleteListener(TaskCompletionSource<bool> tcs)
        {
            _tcs = tcs;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                _tcs.TrySetResult(true);
            }
            _tcs.TrySetResult(false);
        }
    }
}