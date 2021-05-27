using StoryWriter.Services;
using StoryWriter.Services.Stories;

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