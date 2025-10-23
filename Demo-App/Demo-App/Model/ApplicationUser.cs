using Microsoft.AspNetCore.Identity;
using System;

namespace Demo_App.Model
{
    public class ApplicationUser : IdentityUser
    {
        // Extra properties for registration
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        // Automatically updated timestamp
        public DateTime UpdatedAt { get; set; }
    }
}
