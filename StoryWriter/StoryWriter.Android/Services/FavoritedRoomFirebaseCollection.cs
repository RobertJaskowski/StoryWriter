using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using StoryWriter.Services;
using StoryWriter.Services.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryWriter.Droid.Services
{
    public class FavoritedRoomFirebaseCollection<T> : BaseFirebaseCollection<T>, IFavoritedRoomFC<T> where T : IIdentifiable
    {
        protected override string DocumentPath =>
               "users/"
               + Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid
               + "/favoritedRooms";
    }
}