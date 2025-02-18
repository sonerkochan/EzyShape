using EzyShape.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Models.WorkoutSplit
{

    public class WorkoutSplitViewModel
    {
        public int WorkoutId { get; set; }

        public int SplitId { get; set; }

        public IEnumerable<Workout> Workouts { get; set; } = new List<Workout>();
    }
}
