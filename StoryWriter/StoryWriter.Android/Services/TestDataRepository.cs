using System;
using StoryWriter.Droid.Services;
using StoryWriter.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(TestDataRepository))]
namespace StoryWriter.Droid.Services
{
    public class TestDataRepository : BaseRepository<TestData>
    {
        protected override string DocumentPath =>
            "users/"
            + Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid
            + "/test";
    }
}
