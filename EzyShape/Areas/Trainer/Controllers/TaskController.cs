using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Exercises;
using EzyShape.Core.Services;
using EzyShape.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Linq;

namespace EzyShape.Areas.Trainer.Controllers
{
    public class TaskController : BaseController
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService _taskService)
        {
            taskService = _taskService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(AddTaskViewModel addTaskViewModel)
        {
            var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new { success = false, errors });
            }

            try
            {
                await taskService.AddTaskAsync(addTaskViewModel, trainerId);
                return Json(new { success = true, message = "Task added successfully!" });
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return Json(new { success = false, errors = new[] { "An error occurred while adding the task: " + ex.Message } });
            }
        }

    }
}
