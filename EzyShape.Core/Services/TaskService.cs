using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Exercises;
using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data.Models;
using EzyShape.Web.ViewModels;
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
    }
}
