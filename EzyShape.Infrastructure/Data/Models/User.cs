using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

        [Description("Id of this user's trainer.")]
        public string? TrainerId { get; set; }

        [ForeignKey(nameof(TrainerId))]
        public User? Trainer { get; set; }

        public IEnumerable<ClientSplit> SplitIds { get; set; } = new List<ClientSplit>();



        [Description("Registration date of the client/trainer.")]
        public DateTime? RegistrationDate { get; set; }

        [Description("Hexadecimal color code for user profile photo when there is no picture uploaded.")]
        public string? ColorCode { get; set; }

    }
}