using StoryWriter.Droid.Services;
using StoryWriter.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(MyTestDataFirebaseCollection))]

namespace StoryWriter.Droid.Services
{
    public class MyTestDataFirebaseCollection : BaseFirebaseCollection<TestData>
    {
        protected override string DocumentPath =>
            "users/"
            + Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid
            + "/test";
    }
}