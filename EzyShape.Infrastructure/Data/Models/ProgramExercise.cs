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
    public class ProgramExercise
    {

        [Required]
        [Description("Id of the program.")]
        public int ProgramId { get; set; }

        [ForeignKey(nameof(ProgramId))]
        public Program Program { get; set; }

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
