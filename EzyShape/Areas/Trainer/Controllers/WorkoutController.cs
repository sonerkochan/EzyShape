using EzyShape.Core.Models.Exercises;
using EzyShape.Core.Models.WorkoutExercises;
using EzyShape.Core.Models.Workouts;
using EzyShape.Core.Services;
using EzyShape.Infrastructure.Data;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EzyShape.Areas.Trainer.Controllers
{
    public class WorkoutController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public WorkoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("/workouts")]
        [HttpGet]
        public IActionResult AllWorkouts()
        {
            var workouts = _context.Workouts.ToList();
            return View(workouts);
        }


        [HttpGet]
        public async Task<IActionResult> AddWorkout()
        {
            var model = new AddWorkoutViewModel
            {
                Exercises = _context.Exercises.ToList()
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

                _context.Workouts.Add(workout);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(AllWorkouts));
            }

            model.Exercises = _context.Exercises.ToList();
            return RedirectToAction(nameof(AllWorkouts));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var workout = await _context.Workouts
                .Include(w => w.ExerciseIds)
                .ThenInclude(we => we.Exercise)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (workout == null)
            {
                return NotFound();
            }

            return View(workout);
        }

        [HttpGet]
        public  async Task<IActionResult> AssignExercise(int id)
        {
            var model = new WorkoutExerciseViewModel
            {
                WorkoutId = id,
                Exercises = _context.Exercises.ToList()
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

                _context.WorkoutExercises.Add(workoutExercise);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction(nameof(AllWorkouts));

        }

    }
}
