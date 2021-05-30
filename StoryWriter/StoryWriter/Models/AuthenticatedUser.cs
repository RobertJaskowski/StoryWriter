using System;

namespace StoryWriter.Models
{
    public class AuthenticatedUser
    {
        public string Id { get; set; }
        //profile id //users/id
        public string UserId { get; set; }
        public string Nickname { get; set; }
    }
}