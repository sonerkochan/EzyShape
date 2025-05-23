﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EzyShape.Core.Models.User;
using EzyShape.Infrastructure.Data.Models;
using EzyShape.Core.Contracts;
using System.Security.Claims;

namespace EzyShape.Controllers
{
    /// <summary>
    /// The controller is responsible for user management.
    /// </summary>
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly IUtilityService utilityService;


        /// <summary>
        /// Constructor for the user controller.
        /// </summary>
        public UserController(
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            RoleManager<IdentityRole> _roleManager,
            IUtilityService _utilityService)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            utilityService = _utilityService;
        }

        /// <summary>
        /// The register method for the controller.
        /// </summary>
        /// <returns>An empty 'RegisterViewModel'.</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new RegisterViewModel();

            return View(model);
        }

        /// <summary>
        /// The register method for the controller.
        /// </summary>
        /// <param name="model">'RegisterViewModel' filled with data in the registration form.</param>
        /// <returns>Registers the user in the system if everything is okay.</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string ColorCode = await utilityService.GenerateRandomLightHexColorAsync();

            var user = new User()
            {
                Email = model.Email,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ColorCode = ColorCode,
                RegistrationDate = DateTime.Now
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {

                var roleName = "Trainer";
                var roleExists = await roleManager.RoleExistsAsync(roleName);

                if (roleExists)
                {
                    var roleResult = await userManager.AddToRoleAsync(user, roleName);
                }

                return RedirectToAction("Login", "User");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }

        /// <summary>
        /// The login action for the controller.
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new LoginViewModel();

            return View(model);
        }


        /// <summary>
        /// The login action for the controller.
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid login");

            return View(model);
        }

        /// <summary>
        /// The log out method of the controller.
        /// </summary>
        /// <returns>Returns the user to the index page.</returns>
        public async Task<IActionResult> Logout()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);
            user.LastOnline = DateTime.UtcNow;
            await userManager.UpdateAsync(user);


            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
