using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Models.Requests
{
    public class AssignSplitRequest
    {
        public string ClientId { get; set; }
        public List<int> SplitIds { get; set; }
    }
}
