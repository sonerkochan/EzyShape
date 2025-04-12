using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EzyShape.Infrastructure.Data.Models
{
    public class WeightLog
    {
        [Key]
        [Description("ID of the WeightLog")]
        public int Id { get; set; }

        [Required]
        [Description("Weight in kilograms")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Weight must be a positive number.")]
        public decimal Weight { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Description("Date when the weight was logged")]
        public DateTime LogDate { get; set; }

        [Required]
        [Description("ID of the user who made the weight log")]
        public string UserId { get; set; } = null!;

        // Optional: Navigation property if using Identity or a custom User class
        // public ApplicationUser User { get; set; } = null!;
    }
}
