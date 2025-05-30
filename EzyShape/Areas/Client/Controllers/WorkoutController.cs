﻿using EzyShape.Core.Contracts;
using EzyShape.Core.Models.WorkoutLog;
using EzyShape.Core.Services;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;

namespace EzyShape.Areas.Client.Controllers
{
    public class WorkoutController : BaseController
    {
        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly IClientService clientService;

        private readonly ISplitService splitService;

        private readonly IWorkoutService workoutService;

        private readonly IUserService userService;

        private readonly IUtilityService utilityService;

        public WorkoutController(
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            RoleManager<IdentityRole> _roleManager,
            IUserService _userService,
            IClientService _clientService,
            IUtilityService _utilityService,
            ISplitService _splitService,
            IWorkoutService _workoutService
            )
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            userService = _userService;
            clientService = _clientService;
            utilityService = _utilityService;
            splitService = _splitService;
            workoutService = _workoutService;
        }

        [Route("/programs")]
        [HttpGet]
        public async Task<IActionResult> Programs()
        {
            var clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await clientService.GetClientWorkoutsInfoAsync(clientId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetSplitWorkoutsPartial(int id)
        {
            var model = await splitService.GetDetailedSplitAsync(id);

            if (model.WorkoutIds == null || !model.WorkoutIds.Any())
            {
                return new EmptyResult(); // Or return Json(null), or your own logic
            }

            return PartialView("_SplitWorkoutsPartial", model);
        }

        [HttpGet]
        public async Task<IActionResult> WorkoutSession(int id)
        {
            var model = await workoutService.GetWorkoutByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogWorkout([FromBody] WorkoutLogViewModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid model.");
            }
            var clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            

            try
            {
                await workoutService.LogWorkoutAsync(model, clientId);

                return Json(new { redirectUrl = Url.Action(nameof(Programs)) });

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error logging workout: " + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
