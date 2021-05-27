using StoryWriter.Services;

namespace StoryWriter.Models
{
    public class MyTestData : IIdentifiable
    {
        public string Id { get; set; }

        public string name { get; set; }
        public bool flag { get; set; }
    }
}