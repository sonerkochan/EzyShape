using EzyShape.Core.Contracts;
using EzyShape.Core.Services;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EzyShape.Areas.Trainer.Controllers
{
    public class TrainerController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly ITrainerService trainerService;

        public TrainerController(
            UserManager<User> _userManager,
            ITrainerService _trainerService
            )
        {
            userManager = _userManager;
            trainerService = _trainerService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
