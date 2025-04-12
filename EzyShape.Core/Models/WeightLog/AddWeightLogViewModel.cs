using System.ComponentModel.DataAnnotations;

namespace EzyShape.Core.Models.WeightLog
{
    public class AddWeightLogViewModel
    {
        [Required(ErrorMessage = "Weight is required.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Weight must be a positive number.")]
        [Display(Name = "Weight (kg)")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Log Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Log Date")]
        public DateTime LogDate { get; set; }

        [Display(Name = "User ID")]
        public string? UserId { get; set; }
    }
}
