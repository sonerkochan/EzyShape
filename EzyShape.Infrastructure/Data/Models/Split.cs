using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Infrastructure.Data.Models
{
    public class Split
    {
        [Key]
        [Description("Id of the split")]
        public int Id { get; set; }

        [Required]
        [Description("Name of the split")]
        public string Name { get; set; } = null!;

        [Description("Description of the split")]
        public string? Descriptions { get; set; }

        [Description("List of exercises in the split.")]
        public IEnumerable<SplitExercise> ExerciseIds { get; set; } = new List<SplitExercise>();


        [Description("Id of the user that made the split.")]
        public string UserId { get; set; } = null!;


    }
}
