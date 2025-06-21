using EzyShape.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EzyShape.Areas.Client.Controllers
{
    public class NoteController : BaseController
    {
        private readonly INoteService noteService;

        public NoteController(INoteService _noteService)
        {
            noteService = _noteService;
        }

        [HttpPost]
        public async Task<IActionResult> ArchiveNote([FromBody] ArchiveNoteRequest request)
        {
            int noteId =
            request.NoteId;
            try
            {
                var clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var note = await noteService.GetNoteByIdAsync(noteId);

                if (note == null)
                {
                    return Json(new { success = false, errors = new[] { "Note not found." } });
                }

                if (note.ClientId != clientId)
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
    public class ArchiveNoteRequest
    {
        public int NoteId { get; set; }
    }
}
