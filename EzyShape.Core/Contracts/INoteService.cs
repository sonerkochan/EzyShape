using EzyShape.Core.Models.Notes;
using EzyShape.Core.Models.Tasks;
using EzyShape.Infrastructure.Data.Models;
using EzyShape.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Contracts
{
    public interface INoteService
    {
        Task AddNoteAsync(AddTrainerNoteViewModel model, string trainerId, string clientId);
        Task<IEnumerable<NoteViewModel>> GetClientAllNotes(string clientId);

        Task<TrainerNote> GetNoteByIdAsync(int noteId);
        Task UpdateNoteAsync(TrainerNote note);
    }
}
