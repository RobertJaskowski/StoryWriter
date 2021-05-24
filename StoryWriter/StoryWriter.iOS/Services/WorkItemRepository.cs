using System;
using StoryWriter.Models;

namespace StoryWriter.iOS.Services
{
    public class WorkItemRepository : BaseRepository<WorkItem>
    {
        public override string DocumentPath =>
            "users/"
            + Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid
            + "/work";
    }
}
