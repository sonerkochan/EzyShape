using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Exercises;
using EzyShape.Core.Models.Splits;
using EzyShape.Core.Models.WorkoutLog;
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


        [Description("Logs a new workout and records an activity entry.")]
        public async Task LogWorkoutAsync(WorkoutLogViewModel model, string clientId)
        {
            var workoutLog = new WorkoutLog
            {
                Name = model.Name,
                UserId = clientId,
                StartTime = DateTime.UtcNow,
                Duration = TimeSpan.Parse(model.Duration),
            };

            await repo.AddAsync(workoutLog);
            await repo.SaveChangesAsync();

            int totalExercises = 0;
            int totalSets = 0;

            foreach (var exercise in model.Exercises)
            {
                totalExercises++;
                var exerciseLog = new ExerciseLog
                {
                    WorkoutLogId = workoutLog.Id,
                    ExerciseId = exercise.ExerciseId
                };

                await repo.AddAsync(exerciseLog);
                await repo.SaveChangesAsync();

                foreach (var set in exercise.Sets)
                {
                    totalSets++;
                    var setLog = new SetLog
                    {
                        ExerciseLogId = exerciseLog.Id,
                        SetNumber = set.SetNumber,
                        Reps = set.Reps ?? 0,
                        Weight = set.Weight ?? 0
                    };

                    await repo.AddAsync(setLog);
                    await repo.SaveChangesAsync();
                }
            }

            // ✅ Create activity log description
            var description = $"Workout '{model.Name}' completed with {totalExercises} exercise{(totalExercises != 1 ? "s" : "")} and {totalSets} total set{(totalSets != 1 ? "s" : "")}.";

            var activityLog = new ActivityLog
            {
                Description = description,
                CreatedOn = DateTime.UtcNow,
                ClientId = clientId
            };

            await repo.AddAsync(activityLog);
            await repo.SaveChangesAsync();
        }
    }
}
