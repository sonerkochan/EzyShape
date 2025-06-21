using EzyShape.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EzyShape.Areas.Trainer.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService noteService;

        public NoteController(INoteService _noteService)
        {
            noteService = _noteService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNote(AddTrainerNoteViewModel model, string clientId, string trainerId)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new { success = false, errors });
            }

            try
            {
                await noteService.AddNoteAsync(model, trainerId, clientId);
                return RedirectToAction("Overview", "Client", new { area = "Trainer", clientId = clientId });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errors = new[] { "An error occurred while adding the note: " + ex.Message } });
            }
        }


        [HttpPost]
        public async Task<IActionResult> ArchiveNote(int noteId)
        {
            try
            {
                var clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var note = await noteService.GetNoteByIdAsync(noteId);

                if (note == null)
                {
                    return Json(new { success = false, errors = new[] { "Note not found." } });
                }

                if (note.TrainerId != clientId)
                {
                    return Json(new { success = false, errors = new[] { "You are not authorized to archive this note." } });
                }

                note.IsArchived = true;
                await noteService.UpdateNoteAsync(note);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errors = new[] { "An error occurred while archiving the note: " + ex.Message } });
            }
        }
    }
}
