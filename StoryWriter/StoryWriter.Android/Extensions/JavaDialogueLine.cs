using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using StoryWriter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoryWriter.Droid.Extensions
{
    public class JavaDialogueLine : Java.Lang.Object
    {
        public string Id { get; set; }
        public string Line { get; set; }
        public JavaCharacter Character { get; set; }
        public JavaAuthenticatedUser AuthorUser { get; set; }

        public JavaDialogueLine()
        {
        }

        public JavaDialogueLine(DialogueLine dialogueLine)
        {
            Id = dialogueLine.Id;
            Line = dialogueLine.Line;
            Character = new JavaCharacter(dialogueLine.Character);
            AuthorUser = new JavaAuthenticatedUser(dialogueLine.AuthorUser);
        }
    }
}