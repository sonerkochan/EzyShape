using EzyShape.Core.Contracts;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EzyShape.Areas.Trainer.Controllers
{
    public class ExerciseController : BaseController
    {
        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly ITrainerService trainerService;

        private readonly IUserService userService;

        public ExerciseController(
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            RoleManager<IdentityRole> _roleManager,
            IUserService _userService,
            ITrainerService _trainerService
            )
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            userService = _userService;
            trainerService = _trainerService;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
