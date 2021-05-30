using Android.App;
using Android.Widget;
using StoryWriter.Droid;
using StoryWriter.Services;

[assembly: Xamarin.Forms.Dependency(typeof(MessageAndroid))]

namespace StoryWriter.Droid
{
    public class MessageAndroid : IMessageService
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}