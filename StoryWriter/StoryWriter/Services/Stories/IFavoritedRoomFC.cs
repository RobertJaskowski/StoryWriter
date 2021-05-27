namespace StoryWriter.Services.Stories
{
    public interface IFavoritedRoomFC<T> : IFirebaseCollection<T> where T : IIdentifiable
    {
    }
}