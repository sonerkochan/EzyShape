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
    public class ExerciseLog
    {
        [Key]
        [Description("Unique identifier for the exercise log")]
        public int Id { get; set; }

        [Required]
        [Description("ID of the associated workout log")]
        public int WorkoutLogId { get; set; }

        [ForeignKey(nameof(WorkoutLogId))]
        [Description("Reference to the associated workout log")]
        public WorkoutLog WorkoutLog { get; set; }

        [Required]
        [Description("ID of the exercise performed (FK to Exercise entity)")]
        public int ExerciseId { get; set; }

        // Navigation property to SetLogs
        [InverseProperty("ExerciseLog")]
        [Description("Collection of sets performed during this exercise")]
        public ICollection<SetLog> SetLogs { get; set; }
    }


}
