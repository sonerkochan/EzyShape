using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EzyShape.Infrastructure.Data.Models
{
    public class WorkoutSplit
    {
        [Required]
        [Description("Id of the workout")]
        public int WorkoutId { get; set; }

        [ForeignKey(nameof(WorkoutId))]
        public Workout Workout { get; set; }

        [Required]
        [Description("Id of the split")]
        public int SplitId { get; set; }

        [ForeignKey(nameof(SplitId))]
        public Split Split { get; set; }

    }
}
