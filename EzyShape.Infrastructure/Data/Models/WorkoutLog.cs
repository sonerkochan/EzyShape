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


        [Description("Id of the exercise which will be logged.")]
        public int? WorkoutExerciseId { get; set; }

        [ForeignKey(nameof(WorkoutExerciseId))]
        public WorkoutExercise? WorkoutExercise { get; set; }

        public int SetNumber { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
    }
}
