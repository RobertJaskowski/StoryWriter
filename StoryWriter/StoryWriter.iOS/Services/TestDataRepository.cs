using System;
using StoryWriter.iOS.Services;
using StoryWriter.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(TestDataRepository))]
namespace StoryWriter.iOS.Services
{
    public class TestDataRepository : BaseRepository<TestData>
    {
        public override string DocumentPath =>
            "users/"
            + Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid
            + "/test";
    }
}
