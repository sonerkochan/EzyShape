using EzyShape.Core.Contracts;
using EzyShape.Core.Services;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EzyShape.Areas.Trainer.Controllers
{
    public class TrainerController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly ITrainerService trainerService;
        private readonly IDashboardService dashboardService;

        public TrainerController(
            UserManager<User> _userManager,
            ITrainerService _trainerService,
            IDashboardService _dashboardService
            )
        {
            userManager = _userManager;
            trainerService = _trainerService;
            dashboardService= _dashboardService;
        }

        [Route("/dashboard")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var model = await dashboardService.GetTrainerDashboardInfo(trainerId);

            return View(model);
        }

        /*
         
        [Route("/clients")]
        [HttpGet]
        public async Task<IActionResult> AllClients()
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await trainerService.GetTrainersAllClients(trainerId);

            return View(model);
        }

         */
    }
}
