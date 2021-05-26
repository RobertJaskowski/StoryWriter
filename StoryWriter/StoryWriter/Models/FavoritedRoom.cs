using StoryWriter.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoryWriter.Models
{
    public class FavoritedRoom : IIdentifiable
    {
        public string Id { get; set; }
        public string FavoritedRoomId { get; set; }
    }
}
