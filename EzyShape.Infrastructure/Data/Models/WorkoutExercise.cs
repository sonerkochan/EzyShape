using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Infrastructure.Data.Models
{
    public class WorkoutExercise
    {

        [Required]
        [Description("Id of the WorkoutExercise.")]
        public int Id { get; set; }

        [Required]
        [Description("Id of the exercise.")]
        public int ExerciseId { get; set; }

        [ForeignKey(nameof(ExerciseId))]
        public Exercise Exercise { get; set; }

        [Description("Amounts of sets of this exercise.")]
        public string? Sets { get; set; }
        
        [Description("Amounts of reps in each set.")]
        public string? Repetitions { get; set; }

        [Description("Tempo of execution.")]
        public string? Tempo { get; set; }

        [Description("Resting time between sets.")]
        public string? Rest { get; set; }
    }
}
