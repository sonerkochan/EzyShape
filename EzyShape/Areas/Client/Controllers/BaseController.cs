using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static EzyShape.Areas.Client.Constants.ClientConstants;

namespace EzyShape.Areas.Client.Controllers
{
    /// <summary>
    /// Base controller class that all other controllers in Admin area inherit in order to lock authorization.
    /// </summary>
    [Area(ClientAreaName)]
    [Route("/Client/[controller]/[Action]/{id?}")]
    [Authorize(Roles = ClientAreaName)]
    public class BaseController : Controller
    {

    }
}
