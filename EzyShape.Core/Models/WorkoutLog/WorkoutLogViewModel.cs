using System.Text.Json.Serialization;

namespace EzyShape.Core.Models.WorkoutLog
{


    public class WorkoutLogViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string StartDate { get; set; }

        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        [JsonPropertyName("exercises")]
        public List<ExerciseLogViewModel> Exercises { get; set; }
    }




}