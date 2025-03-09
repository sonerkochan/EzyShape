using EzyShape.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static EzyShape.Areas.Trainer.Constants.TrainerConstants;
using static EzyShape.Areas.Client.Constants.ClientConstants;

namespace EzyShape.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            if (User.IsInRole(TrainerRoleName))
            {
                return RedirectToAction("Index", "Trainer", new { area = "Trainer" });
            }

            if (User.IsInRole(ClientRoleName))
            {
                return RedirectToAction("Index", "Client", new { area = "Client" });
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}