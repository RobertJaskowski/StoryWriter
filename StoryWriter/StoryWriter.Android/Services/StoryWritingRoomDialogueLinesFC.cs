using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using StoryWriter.Services;
using StoryWriter.Services.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryWriter.Droid.Services
{
    public class StoryWritingRoomDialogueLinesFC<T> : BaseFirebaseCollection<T>, IStoryWritingRoomDialogueLinesFC<T> where T : IIdentifiable
    {
        protected override string CollectionPath => "stories/";//todo
    }
}