using EzyShape.Core.Models.Exercises;
using EzyShape.Core.Models.Splits;
using EzyShape.Core.Models.Tasks;
using EzyShape.Infrastructure.Data.Models;
using EzyShape.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Contracts
{
    public interface ITaskService
    {
        Task AddTaskAsync (AddTaskViewModel model, string trainerId);
        Task<IEnumerable<TaskViewModel>> GetTrainersAllTasks(string TrainerId);

        Task<TrainingTask> GetTaskByIdAsync(int taskId);
        Task UpdateTaskAsync(TrainingTask task);
    }
}
