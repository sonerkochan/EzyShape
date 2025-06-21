using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Notes;
using EzyShape.Infrastructure.Data;
using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data.Models;
using EzyShape.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EzyShape.Core.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository repo;
        private readonly ApplicationDbContext _context;

        public NoteService(IRepository _repo,
                           ApplicationDbContext context)
        {
            repo = _repo;
            _context = context;
        }

        [Description("Creates a new trainer note and saves it to the database.")]
        public async Task AddNoteAsync(AddTrainerNoteViewModel model, string trainerId, string clientId)
        {
            var note = new TrainerNote()
            {
                ClientId = clientId,
                TrainerId = trainerId,
                Title = model.Title,
                Content = model.Content,
                CreatedAt = DateTime.UtcNow,
                IsArchived = false
            };

            await repo.AddAsync(note);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<NoteViewModel>> GetClientAllNotes(string clientId)
        {
            return await repo.AllReadonly<TrainerNote>()
                .Where(n => n.ClientId == clientId)
                .OrderByDescending(n => n.CreatedAt)
                .Select(n => new NoteViewModel
                {
                    Id = n.Id,
                    ClientId = n.ClientId,
                    TrainerId = n.TrainerId,
                    Title = n.Title,
                    Content = n.Content,
                    CreatedAt = n.CreatedAt,
                    IsArchived = n.IsArchived
                })
                .ToListAsync();
        }
        public async Task<IEnumerable<NoteViewModel>> GetClientActiveNotes(string clientId)
        {
            return await repo.AllReadonly<TrainerNote>()
                .Where(n => n.ClientId == clientId && !n.IsArchived)
                .OrderByDescending(n => n.CreatedAt)
                .Select(n => new NoteViewModel
                {
                    Id = n.Id,
                    ClientId = n.ClientId,
                    TrainerId = n.TrainerId,
                    Title = n.Title,
                    Content = n.Content,
                    CreatedAt = n.CreatedAt,
                    IsArchived = n.IsArchived
                })
                .ToListAsync();
        }

        public async Task<TrainerNote> GetNoteByIdAsync(int noteId)
        {
            return await _context.TrainerNotes.FindAsync(noteId);
        }

        public async Task UpdateNoteAsync(TrainerNote note)
        {
            _context.TrainerNotes.Update(note);
            await _context.SaveChangesAsync();
        }
    }
}
