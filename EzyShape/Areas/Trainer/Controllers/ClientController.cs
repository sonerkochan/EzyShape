using EzyShape.Core.Contracts;
using EzyShape.Core.Models.User;
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

        private readonly IUserService userService;

        public ClientController(
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            RoleManager<IdentityRole> _roleManager,
            IUserService _userService
            )
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            userService = _userService;
        }

        [HttpGet]
        public IActionResult CreateClient()
        {
            var model = new ClientRegisterViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientRegisterViewModel model)
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            model.UserName = model.FirstName + userService.GetUsersCount().ToString();
            model.Password = $"{model.FirstName}{model.LastName}123";
            model.ConfirmPassword = model.Password;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                TrainerId = trainerId
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

                return RedirectToAction("Index", "Trainer");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }
    }
}
