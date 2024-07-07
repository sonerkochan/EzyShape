using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Exercise;
using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Services
{
    public class ExerciseService : IExerciseService
    {

        private readonly IRepository repo;

        public ExerciseService(IRepository _repo)
        {
            repo = _repo;
        }


        [Description("Creates a new exercise and adds it to the database.")]
        public async Task AddExerciseAsync(AddExerciseViewModel model, string trainerId)
        {
            var entity = new Exercise()
            {
                Name = model.Name,
                Link = model.Link,
                Notes = model.Notes,
                MuscleId = model.MuscleId,
                CategoryId = model.CategoryId,
                LevelId = model.LevelId,
                EquipmentId = model.EquipmentId,
                UserId = trainerId
            };

            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
        }


        [Description("Returns all muscles as a list.")]
        public async Task<IEnumerable<Muscle>> GetMusclesAsync()
        {
            return await repo.All<Muscle>().ToListAsync();
        }


        [Description("Returns all categories as a list.")]
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await repo.All<Category>().ToListAsync();
        }


        [Description("Returns all levels as a list.")]
        public async Task<IEnumerable<Level>> GetLevelsAsync()
        {
            return await repo.All<Level>().ToListAsync();
        }


        [Description("Returns all equipments as a list.")]
        public async Task<IEnumerable<Equipment>> GetEquipmentsAsync()
        {
            return await repo.All<Equipment>().ToListAsync();
        }
    }
}
