using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Clients;
using EzyShape.Core.Models.Exercises;
using EzyShape.Core.Models.Splits;
using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly IRepository repo;
        private readonly UserManager<User> userManager;

        public TrainerService(
            IRepository _repo,
            UserManager<User> _userManager)
        {
            repo = _repo;
            userManager = _userManager;
        }

        public async Task<ClientViewModel> GetClientById(string clientId)
        {
            return await repo.AllReadonly<User>()
                .Where(u => u.Id == clientId)
                .Select(u => new ClientViewModel()
                {
                    Id = u.Id,
                    Username = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ClientSmallViewModel>> GetTrainersAllClients(string TrainerId)
        {
            return await repo.AllReadonly<User>()
                .OrderByDescending(u => u.RegistrationDate)
                .ThenBy(u => u.LastName)
                .Where(u => u.TrainerId == TrainerId)
                .Select(u => new ClientSmallViewModel()
                {
                    Id = u.Id,
                    Username = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    ColorCode = u.ColorCode
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ExerciseViewModel>> GetTrainersAllExercises(string TrainerId)
        {
            return await repo.AllReadonly<Exercise>()
                .Where(e => e.UserId == TrainerId)
                .Select(e => new ExerciseViewModel()
                {
                    Name = e.Name,
                    Link = e.Link,
                    Notes = e.Notes,
                    Muscle = e.Muscle.Name,
                    Category = e.Category.Name,
                    Level = e.Level.Name,
                    Equipment = e.Equipment.Name
                })
                .ToListAsync();
        }


        public async Task<IEnumerable<SplitViewModel>> GetTrainersAllSplits(string TrainerId)
        {
            return await repo.AllReadonly<Split>()
                .Where(s => s.UserId == TrainerId)
                .Select(s => new SplitViewModel()
                {
                    Name = s.Name,
                    Description=s.Description
                })
                .ToListAsync();
        }
    }
}
