using System;
using StoryWriter.Droid.Services;
using StoryWriter.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(TestDataFirebaseCollection))]
namespace StoryWriter.Droid.Services
{
    public class TestDataFirebaseCollection : BaseFirebaseCollection<MyTestData>
    {
        protected override string CollectionPath =>
            "mytestData/"
            + Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid
            + "/mytest";
    }
}
