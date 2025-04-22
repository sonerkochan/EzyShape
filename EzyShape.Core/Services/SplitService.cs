using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Splits;
using EzyShape.Infrastructure.Data;
using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data.Models;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace EzyShape.Core.Services
{
    public class SplitService : ISplitService
    {
        private readonly IRepository repo;
        private readonly ApplicationDbContext context;

        public SplitService(IRepository _repo,
                            ApplicationDbContext _context)
        {
            repo = _repo;
            context = _context;
        }


        [Description("Creates a new split and adds it to the database.")]
        public async Task AddSplitAsync(AddSplitViewModel model, string trainerId)
        {
            var entity = new Split()
            {
                Name = model.Name,
                Description= model.Description,
                UserId = trainerId
            };

            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
        }

        public async Task<Split> GetDetailedSplitAsync(int id)
        {
            return await context.Splits
            .Include(s => s.WorkoutIds)
            .ThenInclude(ws => ws.Workout) // if you need workout details
            .ThenInclude(wkts=>wkts.ExerciseIds)
            .ThenInclude(e=>e.Exercise)
            .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<SplitViewModel>> GetClientSplitsAsync(string clientId)
        {

            return await repo.AllReadonly<ClientSplit>()
                .Where(c => c.UserId==clientId)
                .Select(s => new SplitViewModel()
                {
                    Id = s.SplitId,
                    Name = s.Split.Name,
                    Description = s.Split.Description,
                })
                .ToListAsync();
        }
    }
}
