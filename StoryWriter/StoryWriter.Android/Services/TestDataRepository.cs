using System;
using StoryWriter.Droid.Services;
using StoryWriter.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(TestDataRepository))]
namespace StoryWriter.Droid.Services
{
    public class TestDataRepository : BaseRepository<MyTestData>
    {
        protected override string DocumentPath =>
            "mytestData/"
            + Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid
            + "/mytest";
    }
}
