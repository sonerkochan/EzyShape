using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Exercises;
using EzyShape.Core.Models.Splits;
using EzyShape.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EzyShape.Areas.Trainer.Controllers
{
    public class SplitController : BaseController
    {

        private readonly ISplitService splitService;

        private readonly ITrainerService trainerService;



        public SplitController(
            ISplitService _splitService,
            ITrainerService _trainerService
            )
        {
            splitService = _splitService;
            trainerService = _trainerService;
        }

        [Route("splits/new")]
        [HttpGet]
        public IActionResult AddSplit()
        {
            var model = new AddSplitViewModel
            {

            };

            return View(model);
        }

        [Route("splits/new")]
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

    }
}
