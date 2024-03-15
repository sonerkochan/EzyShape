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
    public class SplitExercise
    {

        [Required]
        [Description("Id of the Split.")]
        public int SplitId { get; set; }

        [ForeignKey(nameof(SplitId))]
        public Split Split { get; set; }

        [Required]
        [Description("Id of the product.")]
        public int ExerciseId { get; set; }

        [ForeignKey(nameof(ExerciseId))]
        public Exercise Exercise { get; set; }

        [Required]
        [Description("Amounts of sets of this exercise.")]
        public string Sets { get; set; } = null!;
        
        [Required]
        [Description("Amounts of reps in each set.")]
        public string Repetitions { get; set; } = null!;

        [Required]
        [Description("Tempo of execution.")]
        public string Tempo { get; set; } = null!;

        [Required]
        [Description("Resting time between sets.")]
        public string Rest { get; set; } = null!;
    }
}
