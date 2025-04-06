using EzyShape.Core.Contracts;
using EzyShape.Core.Services;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EzyShape.Areas.Client.Controllers
{
    public class WorkoutController : BaseController
    {
        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly IClientService clientService;

        private readonly ISplitService splitService;

        private readonly IUserService userService;

        private readonly IUtilityService utilityService;

        public WorkoutController(
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            RoleManager<IdentityRole> _roleManager,
            IUserService _userService,
            IClientService _clientService,
            IUtilityService _utilityService,
            ISplitService _splitService
            )
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            userService = _userService;
            clientService = _clientService;
            utilityService = _utilityService;
            splitService = _splitService;
        }

        [Route("/programs")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = await splitService.GetClientSplitsAsync(clientId);

            return View(model);
        }
    }
}
