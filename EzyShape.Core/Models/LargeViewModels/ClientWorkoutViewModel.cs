using EzyShape.Core.Models.Splits;
using EzyShape.Core.Models.WorkoutLog;
namespace EzyShape.Core.Models.LargeViewModels
{
    public class ClientWorkoutViewModel
    {
        public List<SplitViewModel> Splits { get; set; } = new List<SplitViewModel>();

        public List<WorkoutLogViewModel> WorkoutLogs { get; set; } = new List<WorkoutLogViewModel>();
    }
}
