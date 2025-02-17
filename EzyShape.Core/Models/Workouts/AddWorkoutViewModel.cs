using EzyShape.Core.Models.WorkoutExercises;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzyShape.Infrastructure.Data.Models;

namespace EzyShape.Core.Models.Workouts
{
    public class AddWorkoutViewModel
    {
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public List<WorkoutExerciseViewModel> WorkoutExercises { get; set; } = new List<WorkoutExerciseViewModel>();

        public IEnumerable<Exercise> Exercises { get; set; } = new List<Exercise>();

    }
}
