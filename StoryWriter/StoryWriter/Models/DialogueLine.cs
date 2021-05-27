using StoryWriter.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoryWriter.Models
{
    public class DialogueLine : IIdentifiable
    {
        public string Id { get; set; }
        public string Line { get; set; }
        public Character Character { get; set; }
        public AuthenticatedUser AuthorUser { get; set; }
    }
}