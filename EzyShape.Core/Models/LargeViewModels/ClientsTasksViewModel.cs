using EzyShape.Core.Models.Clients;
using EzyShape.Core.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Models.LargeViewModels
{
    public class ClientsTasksViewModel
    {
        public List<ClientSmallViewModel> Clients { get; set; } = new List<ClientSmallViewModel>();
        public List<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
    }
}
