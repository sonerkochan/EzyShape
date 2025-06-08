using EzyShape.Core.Contracts;
using EzyShape.Core.Requests;
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
        private readonly IUtilityService utilityService;

        public TrainerController(
            UserManager<User> _userManager,
            ITrainerService _trainerService,
            IDashboardService _dashboardService,
            IUtilityService _utilityService
            )
        {
            userManager = _userManager;
            trainerService = _trainerService;
            dashboardService= _dashboardService;
            utilityService = _utilityService;
        }



        [Route("/dashboard")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var model = await dashboardService.GetTrainerDashboardInfo(trainerId);

            return View(model);
        }


        [Route("/settings")]
        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var model = await trainerService.GetTrainerInfoAsync(trainerId);

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> ChangeLanguage([FromBody] LanguageRequest languageRequest)
        {
            if (string.IsNullOrEmpty(languageRequest.LanguageCode))
            {
                return BadRequest("Language code is required.");
            }

            var languageCode = languageRequest.LanguageCode;
            var clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await utilityService.ChangePreferredLanguageAsync(clientId, languageCode);


            return Ok(new { success = true });
        }
    }
}
