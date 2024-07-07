using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Exercise;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EzyShape.Areas.Trainer.Controllers
{
    public class ExerciseController : BaseController
    {
        private readonly ITrainerService trainerService;

        private readonly IExerciseService exerciseService;


        public ExerciseController(
            ITrainerService _trainerService,
            IExerciseService _exerciseService
            )
        {
            trainerService = _trainerService;
            exerciseService = _exerciseService;
        }


        [Route("/exercises")]
        [HttpGet]
        public async Task<IActionResult> AllExercises()
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await trainerService.GetTrainersAllExercises(trainerId);

            return View(model);
        }


        [Route("/exercises/new")]
        [HttpGet]
        public async Task<IActionResult> AddExercise()
        {
            var model = new AddExerciseViewModel()
            {
                Muscles = await exerciseService.GetMusclesAsync(),
                Categories = await exerciseService.GetCategoriesAsync(),
                Levels = await exerciseService.GetLevelsAsync(),
                Equipments = await exerciseService.GetEquipmentsAsync()
            };

            return View(model);
        }

        [Route("/exercises/new")]
        [HttpPost]
        public async Task<IActionResult> AddExercise(AddExerciseViewModel addExerciseViewModel)
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                addExerciseViewModel.Muscles = await exerciseService.GetMusclesAsync();
                addExerciseViewModel.Categories = await exerciseService.GetCategoriesAsync();
                addExerciseViewModel.Levels = await exerciseService.GetLevelsAsync();
                addExerciseViewModel.Equipments = await exerciseService.GetEquipmentsAsync();

                return View(addExerciseViewModel);
            }

            try
            {
                await exerciseService.AddExerciseAsync(addExerciseViewModel, trainerId);

                return RedirectToAction("AllExercises", "Exercise");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                addExerciseViewModel.Muscles = await exerciseService.GetMusclesAsync();
                addExerciseViewModel.Categories = await exerciseService.GetCategoriesAsync();
                addExerciseViewModel.Levels = await exerciseService.GetLevelsAsync();
                addExerciseViewModel.Equipments = await exerciseService.GetEquipmentsAsync();

                return View(addExerciseViewModel);
            }
        }

    }
}
