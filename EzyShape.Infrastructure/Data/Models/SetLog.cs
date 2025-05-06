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
    public class SetLog
    {
        [Key]
        [Description("Unique identifier for the set log")]
        public int Id { get; set; }

        [Required]
        [Description("ID of the associated exercise log")]
        public int ExerciseLogId { get; set; }

        [ForeignKey(nameof(ExerciseLogId))]
        [Description("Reference to the associated exercise log")]
        public ExerciseLog ExerciseLog { get; set; }

        [Required]
        [Description("Set number within the exercise")]
        public int SetNumber { get; set; }

        [Range(1, int.MaxValue)]
        [Description("Number of repetitions performed in this set")]
        public int Reps { get; set; }

        [Range(0, double.MaxValue)]
        [Description("Weight used in this set in kg")]
        public double Weight { get; set; }
    }



}
