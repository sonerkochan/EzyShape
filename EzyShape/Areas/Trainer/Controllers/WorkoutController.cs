using EzyShape.Core.Models.Exercises;
using EzyShape.Core.Models.Workouts;
using EzyShape.Core.Services;
using EzyShape.Infrastructure.Data;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
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
                    Descriptions = model.Description,
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
    }
}
