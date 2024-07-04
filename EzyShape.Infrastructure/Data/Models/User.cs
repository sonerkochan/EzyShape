using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace EzyShape.Infrastructure.Data.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;


        [Description("Flag indicating whether the user profile is still active")]
        public bool IsActive { get; set; } = true;

        [Description("List of the Clients of that a user who is a trainer.")]
        public ICollection<User> Clients { get; set; } = new List<User>();
    }
}