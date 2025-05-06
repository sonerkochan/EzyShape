using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EzyShape.Infrastructure.Data.Models
{
    public class WorkoutLog
    {
        [Key]
        [Description("Unique identifier for the workout log")]
        public int Id { get; set; }

        [Required]
        [StringLength(450)]
        [Description("ID of the user performing the workout (FK to AspNetUsers)")]
        public string UserId { get; set; }

        [Required]
        [Description("Start time of the workout session")]
        public DateTime StartTime { get; set; }

        [Required]
        [Description("Duration of the workout session")]
        public TimeSpan Duration { get; set; }

        [MaxLength(500)]
        [Description("Additional notes for the workout session")]
        public string? Notes { get; set; }

        [InverseProperty("WorkoutLog")]
        [Description("Collection of exercises performed during this workout session")]
        public ICollection<ExerciseLog> ExerciseLogs { get; set; }
    }

}
