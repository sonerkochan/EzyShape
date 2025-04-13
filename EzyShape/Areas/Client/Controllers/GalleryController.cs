using EzyShape.Core.Contracts;
using EzyShape.Core.Services;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EzyShape.Areas.Client.Controllers
{
    public class GalleryController : BaseController
    {
        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly IClientService clientService;

        private readonly ISplitService splitService;

        private readonly IUserService userService;

        private readonly IUtilityService utilityService;

        public GalleryController(
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

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {
                var fileName = Path.GetFileName(photo.FileName);

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }

                var clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await clientService.AddPhotoAsync(fileName, clientId);

                return Json(new { success = true, fileName });
            }

            return Json(new { success = false, errors = new[] { "No photo selected." } });
        }




    }
}
