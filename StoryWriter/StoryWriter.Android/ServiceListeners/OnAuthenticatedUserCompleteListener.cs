using System;
using System.Threading.Tasks;
using Android.Gms.Tasks;
using Firebase.Firestore;
using StoryWriter.Models;

namespace StoryWriter.Droid.ServiceListeners
{
    public class OnAuthenticatedUserCompleteListener : Java.Lang.Object, IOnCompleteListener
    {
        private TaskCompletionSource<AuthenticatedUser> _tcs;

        public OnAuthenticatedUserCompleteListener(TaskCompletionSource<AuthenticatedUser> tcs)
        {
            _tcs = tcs;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                // process document
                var result = task.Result;
                if (result is DocumentSnapshot doc)
                {
                    var user = new AuthenticatedUser();
                    user.Id = doc.Id;
                    user.Nickname = doc.GetString("Nickname");
                    _tcs.TrySetResult(user);
                    return;
                }
            }
            // something went wrong
            _tcs.TrySetResult(default(AuthenticatedUser));
        }
    }
}