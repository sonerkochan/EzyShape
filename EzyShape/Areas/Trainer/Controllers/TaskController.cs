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
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return Json(new { success = false, errors = new[] { "An error occurred while adding the task: " + ex.Message } });
            }
        }

        [HttpPost]
        public async Task<IActionResult> FinishTask(int taskId)
        {
            try
            {
                var trainerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var task = await taskService.GetTaskByIdAsync(taskId);

                if (task == null)
                {
                    return Json(new { success = false, errors = new[] { "Task not found." } });
                }

                // Ensure the task belongs to the current trainer
                if (task.UserId != trainerId)
                {
                    return Json(new { success = false, errors = new[] { "You are not authorized to finish this task." } });
                }

                // Update the task status and set CompletedDate
                task.Status = true;
                task.CompletedDate = DateTime.Now;

                await taskService.UpdateTaskAsync(task);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errors = new[] { "An error occurred while finishing the task: " + ex.Message } });
            }
        }

    }
}
