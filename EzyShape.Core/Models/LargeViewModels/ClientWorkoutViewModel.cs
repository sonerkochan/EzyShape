using EzyShape.Core.Models.Clients;
using EzyShape.Core.Models.Splits;
using EzyShape.Core.Models.Tasks;
using EzyShape.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Models.LargeViewModels
{
    public class ClientWorkoutViewModel
    {
        public List<SplitViewModel> Splits { get; set; } = new List<SplitViewModel>();
    }
}
