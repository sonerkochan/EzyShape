using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Infrastructure.Data.Models
{
    public class Exercise
    {

        [Key]
        [Description("Id of the exercise")]
        public int Id { get; set; }

        [Required]
        [Description("Name of the exercise")]
        public string Name { get; set; } = null!;


        [Description("Link to an image or video. YouTube will play as video.")]
        public string? Link { get; set; }

        [Description("Notes to the exercise (optional)")]
        public string? Notes { get; set; }

        [Description("Primary muscles worked with the exercise")]
        public string? PrimaryMuscle { get; set; }

        [Description("Secondary muscles worked with the exercise")]
        public string? SecondaryMuscle { get; set; }

        [Description("Type of the exercise")]
        public string? Type { get; set; }

        [Description("Level of the exercise")]
        public string? Level { get; set; }

        [Description("Equipment used for the exercise")]
        public string? Equipment { get; set; }

        [Description("Id of the user that made the exercise.")]
        public string UserId { get; set; } = null!;
    }
}