using EzyShape.Core.Models.Splits;
using EzyShape.Infrastructure.Data.Models;

namespace EzyShape.Core.Contracts
{
    public interface ISplitService
    {
        Task AddSplitAsync(AddSplitViewModel model, string trainerId);
        Task<Split> GetDetailedSplitAsync(int id);
        Task<IEnumerable<SplitViewModel>> GetClientSplitsAsync(string clientId);
    }
}
