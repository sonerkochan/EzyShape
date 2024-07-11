using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string? Description { get; set; }

        [Description("List of exercises in the workout.")]
        public IEnumerable<WorkoutExercise> ExerciseIds { get; set; } = new List<WorkoutExercise>();


        [Description("Id of the split of which this workout is a part of.")]
        public int? SplitId { get; set; }

        [ForeignKey(nameof(SplitId))]
        public Split? Split { get; set; }


        [Description("Id of the user that made the workout.")]
        public string UserId { get; set; } = null!;


    }
}
