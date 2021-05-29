using StoryWriter.Services;
using System.Collections.Generic;

namespace StoryWriter.Models
{
    public class Story : IIdentifiable
    {
        public string Id { get; set; }
        public bool IsPublic { get; set; }
        public string Title { get; set; }
        public string AdminId { get; set; }
        public List<Character> Characters { get; set; }
        public List<DialogueLine> DialogueLines { get; set; }
    }
}