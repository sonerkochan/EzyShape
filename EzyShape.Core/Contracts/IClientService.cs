using EzyShape.Core.Models.Clients;
using EzyShape.Core.Models.LargeViewModels;
using EzyShape.Core.Models.WeightLog;

namespace EzyShape.Core.Contracts
{
    public interface IClientService
    {
        Task<ClientViewModel> GetClientById(string clientId);
        Task AddWeightAsync(AddWeightLogViewModel model, string clientId);
        Task<ClientProfileViewModel> GetClientProfileInfoAsync(string clientId);
        Task<ClientWorkoutViewModel> GetClientWorkoutsInfoAsync(string clientId);
        Task AddPhotoAsync(string fileName, string clientId);
        Task ChangePreferredLanguageAsync(string clientId, string languageCode);

        
    }
}
