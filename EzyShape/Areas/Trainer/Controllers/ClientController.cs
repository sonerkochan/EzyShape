using Microsoft.AspNetCore.Mvc;

namespace EzyShape.Areas.Trainer.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
