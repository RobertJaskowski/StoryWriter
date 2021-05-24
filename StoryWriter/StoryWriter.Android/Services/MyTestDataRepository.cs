using System;
using StoryWriter.Droid.Services;
using StoryWriter.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(MyTestDataRepository))]
namespace StoryWriter.Droid.Services
{
    public class MyTestDataRepository : BaseRepository<TestData>
    {
        protected override string DocumentPath =>
            "users/"
            + Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid
            + "/test";
    }
}
