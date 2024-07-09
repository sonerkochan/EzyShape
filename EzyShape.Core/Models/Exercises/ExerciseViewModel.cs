using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Models.Exercises
{
    public class ExerciseViewModel
    {
        [Description("Name of the exercise")]
        public string Name { get; set; } = null!;

        [Description("Link to an image or video. YouTube will play as video.")]
        public string? Link { get; set; }

        [Description("Notes to the exercise (optional)")]
        public string? Notes { get; set; }

        [Description("Primary muscles worked with the exercise")]
        public string? Muscle { get; set; }

        [Description("Category of the exercise")]
        public string? Category { get; set; }

        [Description("Level of the exercise")]
        public string? Level { get; set; }

        [Description("Equipment used for the exercise")]
        public string? Equipment { get; set; }
    }
}
