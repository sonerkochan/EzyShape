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
        public int Id { get; set; }

        [Required]
        [Description("Name of the split")]
        public string Name { get; set; } = null!;

        [Description("Description of the split")]
        public string? Description { get; set; }

        [Description("List of workouts in the split.")]
        public IEnumerable<WorkoutSplit> WorkoutIds { get; set; } = new List<WorkoutSplit>();



        [Description("Id of the user that made the split.")]
        public string UserId { get; set; } = null!;

    }
}
