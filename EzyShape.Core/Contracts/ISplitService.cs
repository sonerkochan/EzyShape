using EzyShape.Core.Models.Clients;
using EzyShape.Core.Models.Exercises;
using EzyShape.Core.Models.Splits;
using EzyShape.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Contracts
{
    public interface ISplitService
    {
        Task AddSplitAsync(AddSplitViewModel model, string trainerId);
    }
}
