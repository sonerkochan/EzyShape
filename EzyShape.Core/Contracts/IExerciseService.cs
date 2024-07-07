using EzyShape.Core.Models.Client;
using EzyShape.Core.Models.Exercise;
using EzyShape.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Contracts
{
    public interface IExerciseService
    {
        Task AddExerciseAsync(AddExerciseViewModel model, string trainerId);

        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<Muscle>> GetMusclesAsync();
        Task<IEnumerable<Level>> GetLevelsAsync();
        Task<IEnumerable<Equipment>> GetEquipmentsAsync();
    }
}
