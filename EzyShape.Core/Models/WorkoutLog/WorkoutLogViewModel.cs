using System.Text.Json.Serialization;

namespace EzyShape.Core.Models.WorkoutLog
{


    public class WorkoutLogViewModel
    {
        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        [JsonPropertyName("exercises")]
        public List<ExerciseLogViewModel> Exercises { get; set; }
    }




}