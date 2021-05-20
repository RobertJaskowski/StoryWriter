using System;
using System.Collections.Generic;
using System.Text;

namespace StoryWriter.Model
{
    public class Story
    {
        public Story(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
