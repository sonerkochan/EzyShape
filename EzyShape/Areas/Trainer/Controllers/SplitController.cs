﻿using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Exercises;
using EzyShape.Core.Models.Splits;
using EzyShape.Core.Models.WorkoutExercises;
using EzyShape.Core.Models.WorkoutSplit;
using EzyShape.Core.Services;
using EzyShape.Infrastructure.Data;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EzyShape.Areas.Trainer.Controllers
{
    public class SplitController : BaseController
    {
        private readonly ApplicationDbContext context;

        private readonly ISplitService splitService;

        private readonly ITrainerService trainerService;



        public SplitController(
            ISplitService _splitService,
            ITrainerService _trainerService,
            ApplicationDbContext _context
            )
        {
            splitService = _splitService;
            trainerService = _trainerService;
            context = _context;
        }

        [Route("/splits/new")]
        [HttpGet]
        public IActionResult AddSplit()
        {
            var model = new AddSplitViewModel
            {

            };

            return View(model);
        }

        [Route("/splits/new")]
        [HttpPost]
        public async Task<IActionResult> AddSplit(AddSplitViewModel addSplitViewModel)
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                return View(addSplitViewModel);
            }

            try
            {
                await splitService.AddSplitAsync(addSplitViewModel, trainerId);

                return RedirectToAction("AllSplits", "Split"); // Redirect to Add workouts to Split
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(addSplitViewModel);
            }
        }


        [Route("/splits")]
        [HttpGet]
        public async Task<IActionResult> AllSplits()
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await trainerService.GetTrainersAllSplits(trainerId);

            return View(model);
        }

        [Route("/split/{id}")]
        [HttpGet]
        public async Task<IActionResult> Detail(int splitId)
        {
            var model = await splitService.GetDetailedSplitAsync(splitId);

            ViewBag.AllWorkouts = context.Workouts.ToList(); // pass all workouts for selection

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AssignWorkout(int id)
        {
            var model = new WorkoutSplitViewModel
            {
                SplitId=id,
                Workouts = context.Workouts.ToList()
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AssignWorkout(WorkoutSplitViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                var workoutSplit = new WorkoutSplit
                {
                    SplitId = id,
                    WorkoutId=model.WorkoutId
                };

                context.WorkoutSplits.Add(workoutSplit);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Detail), new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> AssignWorkouts([FromBody] AssignWorkoutsRequest request)
        {
            if (request.WorkoutIds == null || !request.WorkoutIds.Any())
            {
                return Json(new { success = false, errors = new[] { "No workouts selected" } });
            }

            try
            {
                // Get existing assignments for this split to avoid duplicates
                var existingWorkoutIds = context.WorkoutSplits
                    .Where(ws => ws.SplitId == request.SplitId && request.WorkoutIds.Contains(ws.WorkoutId))
                    .Select(ws => ws.WorkoutId)
                    .ToList();

                // Filter only new workouts to add
                var newWorkoutIds = request.WorkoutIds.Where(id => !existingWorkoutIds.Contains(id)).ToList();

                foreach (var workoutId in newWorkoutIds)
                {
                    context.WorkoutSplits.Add(new WorkoutSplit
                    {
                        SplitId = request.SplitId,
                        WorkoutId = workoutId
                    });
                }

                await context.SaveChangesAsync();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errors = new[] { "An error occurred: " + ex.Message } });
            }
        }

    }

    public class AssignWorkoutsRequest
    {
        public int SplitId { get; set; }
        public List<int> WorkoutIds { get; set; }
    }

}