using EzyShape.Core.Models.Clients;
using EzyShape.Core.Models.Splits;
using EzyShape.Core.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Models.LargeViewModels
{
    public class ClientsSplitsViewModel
    {
        public ClientViewModel Client { get; set; } = null!;
        public List<SplitViewModel> Splits { get; set; } = new List<SplitViewModel>();
    }
}
