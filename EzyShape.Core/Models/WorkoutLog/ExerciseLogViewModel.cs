using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EzyShape.Core.Models.WorkoutLog
{

    public class ExerciseLogViewModel
    {
        public string Name { get; set; }

        [JsonPropertyName("exerciseId")]
        public int ExerciseId { get; set; }

        [JsonPropertyName("sets")]
        public List<SetLogViewModel> Sets { get; set; }
    }
}
