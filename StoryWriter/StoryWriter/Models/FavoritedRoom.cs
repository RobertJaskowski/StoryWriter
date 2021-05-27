using StoryWriter.Services;

namespace StoryWriter.Models
{
    public class FavoritedRoom : IIdentifiable
    {
        public string Id { get; set; }
        public string FavoritedRoomId { get; set; }
    }
}