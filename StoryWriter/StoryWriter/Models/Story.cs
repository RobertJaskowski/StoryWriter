using StoryWriter.Services;

namespace StoryWriter.Models
{
    public class Story : IIdentifiable
    {
        public string Id { get; set; }
        public bool IsPublic { get; set; }
        public string Name { get; set; }
    }
}