using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static EzyShape.Infrastructure.Data.Constants.GlobalConstants;

namespace EzyShape.Core.Models.User
{
    /// <summary>
    /// View model to pass data while registering a new client.
    /// </summary>
    public class ClientRegisterViewModel
    {
        [Description("Client's Username.")]
        public string? UserName { get; set; }

        [Required]
        [Description("Client's FirstName.")]
        public string FirstName { get; set; } = null!;


        [Required]
        [Description("Client's LastName.")]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [Description("Client's Email.")]
        public string Email { get; set; } = null!;

        [Description("Client's Password.")]
        public string? Password { get; set; }

        [Description("Client's Password confirmation.")]
        public string? ConfirmPassword { get; set; }
    }
}
