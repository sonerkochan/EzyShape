﻿using System;
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

        [Description("JSON file of all sets made during the workout")]
        public string Logs { get; set; }

        [Required]
        public bool Finished { get; set; } = false; // False means still is running 

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndTime { get; set; }

        [Description("Id of the user performing the workout.")]
        public string UserId { get; set; } = null!;
    }
}
