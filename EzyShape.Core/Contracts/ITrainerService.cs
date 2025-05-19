using EzyShape.Core.Models.Clients;
using EzyShape.Core.Models.Exercises;
using EzyShape.Core.Models.LargeViewModels;
using EzyShape.Core.Models.Splits;
using EzyShape.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Contracts
{
    public interface ITrainerService
    {

        Task<IEnumerable<ClientSmallViewModel>> GetTrainersAllClients(string TrainerId);
        Task<IEnumerable<ExerciseViewModel>> GetTrainersAllExercises(string TrainerId);
        Task<IEnumerable<SplitViewModel>> GetTrainersAllSplits(string TrainerId);
        Task<ClientViewModel> GetClientById(string clientId);

        Task<ClientTrainingViewModel> GetClientTrainingInfoAsync(string TrainerId, string ClientId);
        Task<ClientOverviewViewModel> GetClientOverviewInfoAsync(string clientId);
        
    }
}
