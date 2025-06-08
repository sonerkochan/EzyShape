using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Clients;
using EzyShape.Core.Models.LargeViewModels;
using EzyShape.Core.Models.Photos;
using EzyShape.Core.Models.Splits;
using EzyShape.Core.Models.WeightLog;
using EzyShape.Core.Models.WorkoutLog;
using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace EzyShape.Core.Services
{
    public class ClientService : IClientService
    {

        private readonly IRepository repo;
        private readonly UserManager<User> userManager;

        public ClientService(
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
                    Email = u.Email,
                    ColorCode = u.ColorCode,
                })
                .FirstOrDefaultAsync();
        }


        [Description("Creates a new weight log and adds it to the database.")]
        public async Task AddWeightAsync(AddWeightLogViewModel model, string clientId)
        {
            var entity = new WeightLog()
            {
                Weight = model.Weight,
                UserId = model.UserId,
                LogDate = model.LogDate
            };

            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
        }

        public async Task<ClientProfileViewModel> GetClientProfileInfoAsync(string clientId)
        {
            var model = new ClientProfileViewModel();

            model.Client = await repo.AllReadonly<User>()
                .Where(u => u.Id == clientId)
                .Select(u => new ClientViewModel()
                {
                    Id = u.Id,
                    Username = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    ColorCode = u.ColorCode,
                    PreferredLanguage=u.PreferredLanguage
                })
                .FirstOrDefaultAsync();

            model.WeightLogs = await repo.AllReadonly<WeightLog>()
                .Where(x => x.UserId == clientId)
                .Select(x => new WeightLogViewModel()
                {
                    Weight = x.Weight,
                    LogDate = x.LogDate
                })
                .OrderBy(x => x.LogDate)
                .ToListAsync();

            model.Photos = await repo.AllReadonly<Photo>()
                        .Where(p => p.ClientId == clientId)
                        .Select(p => new PhotoViewModel
                        {
                            FileName = p.FileName,
                            UploadDate = p.UploadDate
                        })
                            .ToListAsync();

            return model;
        }

        public async Task<ClientWorkoutViewModel> GetClientWorkoutsInfoAsync(string clientId)
        {
            var model = new ClientWorkoutViewModel();

            model.Splits = await repo.AllReadonly<ClientSplit>()
                .Where(c => c.UserId == clientId)
                .Select(s => new SplitViewModel()
                {
                    Id = s.SplitId,
                    Name = s.Split.Name,
                    Description = s.Split.Description,
                })
                .ToListAsync();

            model.WorkoutLogs = await repo.AllReadonly<WorkoutLog>()
                .Where(w => w.UserId == clientId)
                .OrderByDescending(w => w.StartTime)
                .Select(w => new WorkoutLogViewModel
                {
                    Name = w.Name,
                    Duration = w.Duration.ToString(@"hh\:mm\:ss"),
                    StartDate =w.StartTime.ToString("dd MMM yyyy"),
                    Exercises = w.ExerciseLogs.Select(e => new ExerciseLogViewModel
                    {
                        ExerciseId = e.ExerciseId,
                        Sets = e.SetLogs.Select(s => new SetLogViewModel
                        {
                            SetNumber = s.SetNumber,
                            Reps = s.Reps,
                            Weight = s.Weight
                        }).ToList()
                    }).ToList()
                }).ToListAsync();


            return model;
        }
        public async Task AddPhotoAsync(string fileName, string clientId)
        {
            var entity = new Photo()
            {
                FileName = fileName,
                UploadDate = DateTime.UtcNow,
                ClientId = clientId
            };

            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
        }
    }
}
