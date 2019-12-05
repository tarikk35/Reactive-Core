using System;

namespace Domain
{
    public class UserActivity
    {
        // EF automatically knows that AppUserId belongs to AppUser
        // And creates a column with this relationship
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid ActivityId { get; set; }
        public Activity Activity { get; set; }
        public DateTime DateJoined { get; set; }
        public bool IsHost { get; set; }
    }
}