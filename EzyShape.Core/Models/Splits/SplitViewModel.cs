using EzyShape.Core.Models.WorkoutExercises;
using EzyShape.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Models.Splits
{
    public class SplitViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
