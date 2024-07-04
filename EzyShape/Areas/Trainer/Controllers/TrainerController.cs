using Microsoft.AspNetCore.Mvc;

namespace EzyShape.Areas.Trainer.Controllers
{
    public class TrainerController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
