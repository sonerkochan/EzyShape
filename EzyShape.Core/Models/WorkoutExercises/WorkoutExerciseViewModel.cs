using EzyShape.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Models.WorkoutExercises
{
    public class WorkoutExerciseViewModel
    {
        public int WorkoutId { get; set; }

        public int ExerciseId { get; set; }

        public string? Sets { get; set; }

        public string? Repetitions { get; set; }

        public string? Tempo { get; set; }

        public string? Rest { get; set; }

        public IEnumerable<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
