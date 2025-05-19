using EzyShape.Core.Models.Clients;
using EzyShape.Core.Models.Splits;
using EzyShape.Core.Models.Tasks;
using EzyShape.Core.Models.WorkoutLog;
using EzyShape.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Models.LargeViewModels
{
    public class ClientTrainingViewModel
    {
        public ClientViewModel Client { get; set; } = null!;
        public List<SplitViewModel> Splits { get; set; } = new List<SplitViewModel>();
        public List<SplitViewModel> ClientSplits { get; set; } = new List<SplitViewModel>();
        public List<WorkoutLogViewModel> WorkoutLogs { get; set; } = new List<WorkoutLogViewModel>();
    }
}
