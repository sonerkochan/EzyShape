using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Infrastructure.Data.Models
{
    public class Workout
    {
        [Key]
        [Description("Id of the workout")]
        public int Id { get; set; }

        [Required]
        [Description("Name of the workout")]
        public string Name { get; set; } = null!;

        [Description("Description of the workout")]
        public string? Descriptions { get; set; }

        [Description("List of exercises in the workout.")]
        public IEnumerable<WorkoutExercise> ExerciseIds { get; set; } = new List<WorkoutExercise>();


        [Description("Id of the user that made the workout.")]
        public string UserId { get; set; } = null!;


    }
}
