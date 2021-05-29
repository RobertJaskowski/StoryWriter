using StoryWriter.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoryWriter.Models
{
    public class Character : IIdentifiable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AuthenticatedUser AuthorUser { get; set; }
    }
}