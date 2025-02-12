using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EzyShape.Infrastructure.Data.Models
{
    public class WorkoutSession
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Finished { get; set; } = false; // False means still is running 


        [Description("Id of the split of which this session's workout is part of")]
        public int? SplitId { get; set; }

        [ForeignKey(nameof(SplitId))]
        public Split? Split { get; set; }


        [Description("Id of the workout done in this session")]
        public int? WorkoutId { get; set; }

        [ForeignKey(nameof(WorkoutId))]
        public Workout? Workout { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndTime { get; set; }

        [Description("Id of the user performing the workout.")]
        public string UserId { get; set; } = null!;
    }
}
