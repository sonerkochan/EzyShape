using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Exercises;
using EzyShape.Core.Models.WorkoutExercises;
using EzyShape.Core.Models.WorkoutLog;
using EzyShape.Core.Models.Workouts;
using EzyShape.Core.Services;
using EzyShape.Infrastructure.Data;
using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EzyShape.Areas.Trainer.Controllers
{
    public class WorkoutController : BaseController
    {
        private readonly ApplicationDbContext context;
        private readonly IWorkoutService workoutService;
        private readonly IRepository repo;


        public WorkoutController(IRepository _repo, 
            ApplicationDbContext _context,
            IWorkoutService _workoutService)
        {
            repo = _repo;
            context = _context;
            workoutService = _workoutService;
        }

        [Route("/workouts")]
        [HttpGet]
        public async Task<IActionResult> AllWorkouts()
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await workoutService.GetTrainersAllWorkouts(trainerId);

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> AddWorkout()
        {
            var model = new AddWorkoutViewModel
            {
                Exercises = context.Exercises.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkout(AddWorkoutViewModel model)
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                var workout = new Workout
                {
                    Name = model.Name,
                    Description = model.Description,
                    ExerciseIds = model.WorkoutExercises.Select(se => new WorkoutExercise
                    {
                        ExerciseId = se.ExerciseId,
                        Sets = se.Sets,
                        Repetitions = se.Repetitions,
                        Tempo = se.Tempo,
                        Rest = se.Rest
                    }).ToList(),
                    UserId = trainerId
                };

                context.Workouts.Add(workout);
                await context.SaveChangesAsync();

                return RedirectToAction(nameof(AllWorkouts));
            }

            model.Exercises = context.Exercises.ToList();
            return RedirectToAction(nameof(AllWorkouts));
        }

        [Route("/workout/{id}")]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var workout = await context.Workouts
                .Include(w => w.ExerciseIds)
                .ThenInclude(we => we.Exercise)
                .FirstOrDefaultAsync(w => w.Id == id);


            ViewBag.AllExercises = context.Exercises.ToList();


            if (workout == null)
            {
                return NotFound();
            }

            return View(workout);
        }

        [HttpGet]
        public  async Task<IActionResult> AssignExercise(int id) // Can be removed.
        {
            var model = new WorkoutExerciseViewModel
            {
                WorkoutId = id,
                Exercises = context.Exercises.ToList()
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AssignExercise(WorkoutExerciseViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                var workoutExercise = new WorkoutExercise
                {
                    WorkoutId = id,
                    ExerciseId = model.ExerciseId,
                    Repetitions = model.Repetitions,
                    Sets = model.Sets,
                    Tempo = model.Tempo
                };

                context.WorkoutExercises.Add(workoutExercise);
                await context.SaveChangesAsync();
            }


            return RedirectToAction(nameof(Details), new { id = id });

        }

        [HttpGet]
        public async Task<IActionResult> CheckLog(int Id)
        {


            var workout = await repo.AllReadonly<WorkoutLog>()
                .Where(w => w.Id == Id)
                .Select(w => new WorkoutLogViewModel
                {
                    Id = w.Id,
                    Name = w.Name,
                    Duration = w.Duration.ToString(@"hh\:mm\:ss"),
                    StartDate = w.StartTime.ToString("dd MMM yyyy"),
                    Exercises = w.ExerciseLogs.Select(e => new ExerciseLogViewModel
                    {
                        ExerciseId = e.ExerciseId,
                        Name = repo.AllReadonly<Exercise>()
                                   .Where(ex => ex.Id == e.ExerciseId)
                                   .Select(ex => ex.Name)
                                   .FirstOrDefault(),
                        Sets = e.SetLogs.Select(s => new SetLogViewModel
                        {
                            SetNumber = s.SetNumber,
                            Reps = s.Reps,
                            Weight = s.Weight
                        }).ToList()
                    }).ToList()
                }).FirstOrDefaultAsync();

            if (workout == null)
            {
                return NotFound();
            }

            // Return partial view instead of full view
            return View("LogView", workout);
        }
    }
}
