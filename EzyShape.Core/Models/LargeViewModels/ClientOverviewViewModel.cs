using EzyShape.Core.Models.Clients;
using EzyShape.Core.Models.Photos;
using EzyShape.Core.Models.Splits;
using EzyShape.Core.Models.Tasks;
using EzyShape.Core.Models.WeightLog;
using EzyShape.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Models.LargeViewModels
{
    public class ClientOverviewViewModel
    {
        public ClientViewModel Client { get; set; } = null!;
        public List<WeightLogViewModel> WeightLogs { get; set; } = new List<WeightLogViewModel>();
        public IEnumerable<PhotoViewModel> Photos { get; set; }

        public ClientWeightStatsViewModel Stats { get; set; }
    }
}
