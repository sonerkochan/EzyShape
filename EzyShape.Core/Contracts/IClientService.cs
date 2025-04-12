using EzyShape.Core.Models.Clients;
using EzyShape.Core.Models.WeightLog;

namespace EzyShape.Core.Contracts
{
    public interface IClientService
    {
        Task<ClientViewModel> GetClientById(string clientId);
        Task AddWeightAsync(AddWeightLogViewModel model, string clientId);
    }
}
