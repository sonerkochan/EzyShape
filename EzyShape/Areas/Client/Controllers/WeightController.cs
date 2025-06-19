using EzyShape.Core.Contracts;
using EzyShape.Core.Models.WeightLog;
using EzyShape.Core.Services;
using EzyShape.Infrastructure.Data.Models;
using EzyShape.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EzyShape.Areas.Client.Controllers
{
    public class WeigthController : BaseController
    {
        private readonly IClientService clientService;

        private readonly IUserService userService;

        public WeigthController(
            IUserService _userService,
            IClientService _clientService
            )
        {
            userService = _userService;
            clientService = _clientService;
        }

         [HttpPost]
        public async Task<IActionResult> AddWeight([FromBody] AddWeightLogViewModel addWeightLogViewModel)
        {
            var clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            addWeightLogViewModel.UserId = clientId;

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new { success = false, errors });
            }

            try
            {
                await clientService.AddWeightAsync(addWeightLogViewModel, clientId);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return Json(new { success = false, errors = new[] { "An error occurred while logging the weight: " + ex.Message } });
            }
        }
    }
}
