using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Clients;
using EzyShape.Core.Models.Exercises;
using EzyShape.Core.Models.Tasks;
using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data.Models;
using EzyShape.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepository repo;

        public TaskService(IRepository _repo)
        {
            repo = _repo;
        }

        [Description("Creates a new exercise and adds it to the database.")]
        public async Task AddTaskAsync(AddTaskViewModel model, string trainerId)
        {
            var entity = new TrainingTask()
            {
                Name = model.Name,
                Description= model.Description,
                Status=false,
                DueDate=model.DueDate,
                CreatedDate=DateTime.Now,
                CompletedDate=null,
                UserId=trainerId
            };

            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
        }


        public async Task<IEnumerable<TaskViewModel>> GetTrainersAllTasks(string TrainerId)
        {
            return await repo.AllReadonly<TrainingTask>()
                .OrderByDescending(t => t.DueDate)
                .Where(t => t.UserId == TrainerId)
                .Select(t => new TaskViewModel()
                {
                    Name = t.Name,
                    Description = t.Description,
                    DueDate = t.DueDate,
                })
                .ToListAsync();
        }
    }
}
