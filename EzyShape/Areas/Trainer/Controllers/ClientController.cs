using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Requests;
using EzyShape.Core.Models.User;
using EzyShape.Core.Models.WorkoutSplit;
using EzyShape.Core.Services;
using EzyShape.Infrastructure.Data;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EzyShape.Areas.Trainer.Controllers
{
    public class ClientController : BaseController
    {
        private readonly ApplicationDbContext context;

        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly ITrainerService trainerService;

        private readonly IClientService clientService;

        private readonly IUserService userService;

        private readonly IUtilityService utilityService;

        public ClientController(
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            RoleManager<IdentityRole> _roleManager,
            IUserService _userService,
            ITrainerService _trainerService,
            IClientService _clientService,
            IUtilityService _utilityService,
            ApplicationDbContext _context
            )
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            userService = _userService;
            trainerService = _trainerService;
            clientService = _clientService;
            utilityService = _utilityService;
            context = _context;
        }

        [Route("/clients/new")]
        [HttpGet]
        public IActionResult CreateClient()
        {
            var model = new ClientRegisterViewModel();

            return View(model);
        }

        [Route("/clients/new")]
        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientRegisterViewModel model)
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            model.UserName = $"{model.FirstName}{(userService.GetUsersCount() + 1)}";
            //
            model.Password = $"{model.FirstName}{model.LastName}123";
            model.ConfirmPassword = model.Password;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string ColorCode = await utilityService.GenerateRandomLightHexColorAsync();

            var user = new User()
            {
                UserName = model.UserName,
                Email = model.Email.ToLower(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                TrainerId = trainerId,
                ColorCode = ColorCode,
                RegistrationDate = DateTime.Now
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {

                var roleName = "Client";
                var roleExists = await roleManager.RoleExistsAsync(roleName);

                await utilityService.SendClientWelcomeEmailAsync(
                                                                user.Email,
                                                                $"{user.FirstName} {user.LastName}",
                                                                user.UserName,
                                                                model.Password);

                if (roleExists)
                {
                    var roleResult = await userManager.AddToRoleAsync(user, roleName);
                }

                return RedirectToAction("AllClients", "Client");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }


        [Route("/clients")]
        [HttpGet]
        public async Task<IActionResult> AllClients()
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await trainerService.GetTrainersAllClients(trainerId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Overview(string clientId)
        {
            var model = await trainerService.GetClientOverviewInfoAsync(clientId);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Metrics(string clientId)
        {
            var model = await clientService.GetClientMetricsAsync(clientId);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Training(string clientId)
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await trainerService.GetClientTrainingInfoAsync(trainerId, clientId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignSplit([FromBody] AssignSplitRequest request)
        {
            var result = new { Success = true, Message = "Splits assigned successfully" };

            try
            {
                if (request.SplitIds == null || !request.SplitIds.Any())
                {
                    return Json(new { success = false, errors = new[] { "No splits selected" } });
                }

                var existingSplits = context.ClientSplits
                    .Where(cs => cs.UserId == request.ClientId && request.SplitIds.Contains(cs.SplitId))
                    .Select(cs => cs.SplitId)
                    .ToList();

                var newSplits = request.SplitIds.Where(splitId => !existingSplits.Contains(splitId)).ToList();

                foreach (var splitId in newSplits)
                {
                    var clientSplit = new ClientSplit
                    {
                        SplitId = splitId,
                        UserId = request.ClientId
                    };

                    context.ClientSplits.Add(clientSplit);
                }

                await context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errors = new[] { "An error occurred: " + ex.Message } });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteClientSplit(int splitId, string clientId)
        {
            var clientSplit = await context.ClientSplits
                .FirstOrDefaultAsync(cs => cs.UserId == clientId && cs.SplitId == splitId);

            if (clientSplit == null)
            {
                return Json(new { success = false, message = "Split not found for this client." });
            }

            context.ClientSplits.Remove(clientSplit);
            await context.SaveChangesAsync();

            return Json(new { success = true });
        }






    }
}
