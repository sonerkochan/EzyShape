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
        public int Id { get; set; }

        [Description("Id of the session.")]
        public int? WorkoutSessionId { get; set; }

        [ForeignKey(nameof(WorkoutSessionId))]
        public WorkoutSession? WorkoutSession { get; set; }


        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }


        [ForeignKey("WorkoutId, ExerciseId")]
        public WorkoutExercise? WorkoutExercise { get; set; }


        public int SetNumber { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
    }
}
