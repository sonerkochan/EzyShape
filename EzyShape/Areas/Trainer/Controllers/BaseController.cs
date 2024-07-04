using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static EzyShape.Areas.Trainer.Constants.TrainerConstants;

namespace EzyShape.Areas.Trainer.Controllers
{
    /// <summary>
    /// Base controller class that all other controllers in Admin area inherit in order to lock authorization.
    /// </summary>
    [Area(TrainerAreaName)]
    [Route("/Trainer/[controller]/[Action]/{id?}")]
    [Authorize(Roles = TrainerAreaName)]
    public class BaseController : Controller
    {

    }
}
