using EzyShape.Core.Contracts;
using EzyShape.Core.Requests;
using EzyShape.Core.Services;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EzyShape.Areas.Client.Controllers
{
    public class ClientController : BaseController
    {
        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly IClientService clientService;

        private readonly IUserService userService;

        private readonly IUtilityService utilityService;

        public ClientController(
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            RoleManager<IdentityRole> _roleManager,
            IUserService _userService,
            IClientService _clientService,
            IUtilityService _utilityService
            )
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            userService = _userService;
            clientService = _clientService;
            utilityService = _utilityService;
        }


        [Route("/home")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var model = await clientService.GetClientById(clientId);

            return View(model);
        }

        [Route("/profile")]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var model = await clientService.GetClientProfileInfoAsync(clientId);

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

            await clientService.ChangePreferredLanguageAsync(clientId, languageCode);


            return Ok(new { success = true });
        }


    }
}
