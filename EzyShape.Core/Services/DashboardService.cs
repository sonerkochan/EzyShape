using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Clients;
using EzyShape.Core.Models.LargeViewModels;
using EzyShape.Core.Models.Tasks;
using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IRepository repo;

        public DashboardService(IRepository _repo)
        {
            repo = _repo;
        }


        public async Task<ClientsTasksViewModel> GetTrainerDashboardInfo(string TrainerId)
        {
            var model = new ClientsTasksViewModel();

            model.Clients = await repo.AllReadonly<User>()
                .OrderByDescending(u => u.RegistrationDate)
                .ThenBy(u => u.LastName)
                .Where(u => u.TrainerId == TrainerId)
                .Take(5)
                .Select(u => new ClientSmallViewModel()
                {
                    Id = u.Id,
                    Username = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    ColorCode = u.ColorCode
                })
                .ToListAsync();

            model.Tasks = await repo.AllReadonly<TrainingTask>()
                .OrderByDescending(t => t.DueDate)
                .Where(t => t.UserId == TrainerId && t.Status == false)
                .Take(5)
                .Select(t => new TaskViewModel()
                {
                    Id= t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    DueDate = t.DueDate,
                })
                .ToListAsync();

            return model;
        }
    }
}
