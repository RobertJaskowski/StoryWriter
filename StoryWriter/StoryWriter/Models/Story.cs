using StoryWriter.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StoryWriter.Models
{
    [Serializable]
    public class Story : IIdentifiable
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool IsPublic { get; set; }
        public string AdminId { get; set; }
        public List<Character> Characters { get; set; }
        public List<DialogueLine> DialogueLines { get; set; }
    }
}