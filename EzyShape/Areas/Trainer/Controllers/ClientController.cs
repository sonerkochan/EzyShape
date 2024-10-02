using EzyShape.Core.Contracts;
using EzyShape.Core.Models.User;
using EzyShape.Core.Services;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EzyShape.Areas.Trainer.Controllers
{
    public class ClientController : BaseController
    {
        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly ITrainerService trainerService;

        private readonly IUserService userService;

        private readonly IUtilityService utilityService;

        public ClientController(
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            RoleManager<IdentityRole> _roleManager,
            IUserService _userService,
            ITrainerService _trainerService,
            IUtilityService _utilityService
            )
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            userService = _userService;
            trainerService = _trainerService;
            utilityService = _utilityService;
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
            var model = await trainerService.GetClientById(clientId);
            return View(model);
        }

    }
}
