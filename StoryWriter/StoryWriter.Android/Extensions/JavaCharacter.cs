using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryWriter.Droid.Extensions
{
    public class JavaCharacter : Java.Lang.Object
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public JavaAuthenticatedUser AuthorUser { get; set; }

        public JavaCharacter()
        {
        }

        public JavaCharacter(Models.Character character)
        {
            Id = character.Id;
            Name = character.Name;
            Description = character.Description;
            AuthorUser = new JavaAuthenticatedUser(character.AuthorUser);
        }
    }
}