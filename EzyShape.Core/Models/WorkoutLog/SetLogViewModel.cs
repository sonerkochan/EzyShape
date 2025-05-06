using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EzyShape.Core.Models.WorkoutLog
{

    public class SetLogViewModel
    {
        [JsonPropertyName("setNumber")]
        public int SetNumber { get; set; }

        [JsonPropertyName("reps")]
        public int? Reps { get; set; }

        [JsonPropertyName("weight")]
        public double? Weight { get; set; }
    }
}
