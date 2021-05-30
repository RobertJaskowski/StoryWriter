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
    public class JavaAuthenticatedUser : Java.Lang.Object
    {
        public string Id { get; set; }

        //profile id //users/id
        public string UserId { get; set; }

        public string Nickname { get; set; }

        public JavaAuthenticatedUser()
        {
        }

        public JavaAuthenticatedUser(AuthenticatedUser auser)
        {
            Id = auser.Id;
            UserId = auser.UserId;
            Nickname = auser.Nickname;
        }
    }
}