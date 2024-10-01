using EzyShape.Core.Models.LargeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Contracts
{
    public interface IDashboardService
    {
        Task<ClientsTasksViewModel> GetTrainerDashboardInfo(string TrainerId);
    }
}
