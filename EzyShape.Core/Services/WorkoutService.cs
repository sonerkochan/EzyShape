using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Exercises;
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
    public class WorkoutService : IWorkoutService
    {

        private readonly IRepository repo;

        public WorkoutService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<Workout>> GetTrainersAllWorkouts(string TrainerId)
        {
            return await repo.AllReadonly<Workout>()
                .Where(e => e.UserId == TrainerId)
                .ToListAsync();
        }

        public async Task<Workout> GetWorkoutByIdAsync(int id)
        {
            return await repo.AllReadonly<Workout>()
                .Where(w => w.Id == id)
                .Include(w => w.ExerciseIds)
                .ThenInclude(e => e.Exercise)
                .FirstOrDefaultAsync();
        }
    }
}
