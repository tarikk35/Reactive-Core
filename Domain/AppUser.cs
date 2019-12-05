using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        // Added for many-to-many relationship
        public virtual ICollection<UserActivity> UserActivities{get;set;}
    }
}