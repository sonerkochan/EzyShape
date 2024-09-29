using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EzyShape.Infrastructure.Data.Models
{
    public class TrainingTask
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Task name is required.")]
        [StringLength(100, ErrorMessage = "Task name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required]
        public bool Status { get; set; } = false;
        
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CompletedDate { get; set; }

        [Description("Id of user/trainer whose task this is.")]
        public string UserId { get; set; } = null!;
    }
}
