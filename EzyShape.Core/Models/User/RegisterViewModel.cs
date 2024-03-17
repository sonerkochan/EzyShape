using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static EzyShape.Infrastructure.Data.Constants.GlobalConstants;

namespace EzyShape.Core.Models.User
{
    /// <summary>
    /// View model to pass data while registering a new user.
    /// </summary>
    public class RegisterViewModel
    {
        [Required]
        [Description("User's Username.")]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [Description("User's Email.")]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Description("User's Password.")]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [Description("User's Password confirmation.")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
